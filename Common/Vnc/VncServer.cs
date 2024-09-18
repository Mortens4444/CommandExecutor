using Common.Extensions;
using Common.Mouse;
using Common.Network;
using Common.Processes;
using Common.Utils;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Vnc
{
    public class VncServer : Socket
	{
		public delegate Task DataArrivedEventHandler(object sender, DataArrivedEventArgs e);
		public delegate Task ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);

		public int ListenerPortOfServer { get; set; }
		public Encoding Encoding = Encoding.UTF8;
		public event DataArrivedEventHandler DataArrived;
		public event ErrorOccurredEventHandler ErrorOccurred;

		private Socket clientSocket;
		private bool working;

		public VncServer(int listenerPort = 0)
			: base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
		{
			working = true;
			if (listenerPort == 0)
			{
				listenerPort = PortUtils.GetFreePort();
			}
			ListenerPortOfServer = listenerPort;

			Bind(new IPEndPoint(IPAddress.Any, listenerPort));
			Listen(Constants.MAX_PENDING_CONNECTION);
			DataArrived += DataArrivedHandlerAsync;
			Task.Run(ListenerEngine);
			Task.Run(ScreenSenderAsync);
		}

		public void Stop()
		{
			working = false;
		}

		private async Task ScreenSenderAsync()
		{
			while (working)
			{
				await Task.Delay(Constants.SCREEN_WAIT_TIME);
				if (clientSocket != null)
				{
					var image = ImageUtils.GetScreenAreaInByteArray(Screen.PrimaryScreen.Bounds, Encoding);
					await SendAsync(clientSocket, image);
					clientSocket = null;
				}
			}
		}

        public bool Send(Socket socket, string message)
        {
            return MessageSender.Send(socket, Encoding.GetBytes(message));
        }

        public bool Send(Socket socket, byte[] bytes)
        {
            return MessageSender.Send(socket, bytes);
        }

        public Task<bool> SendAsync(Socket socket, string message)
        {
            return MessageSender.SendAsync(socket, Encoding.GetBytes(message));
        }

        public Task<bool> SendAsync(Socket socket, byte[] bytes)
        {
            return MessageSender.SendAsync(socket, bytes);
        }

        private void ListenerEngine()
		{
			try
			{
				while (working)
				{
					if (Poll(10, SelectMode.SelectRead))
					{
						BeginAccept(new AsyncCallback(AcceptCallback), this);
					}
				}
			}
			catch (Exception ex)
			{
				OnErrorOccurred(ex);
			}
		}

		private void AcceptCallback(IAsyncResult ar)
		{
			try
			{
				var state = new StateObject
				{
					Socket = ((Socket)ar.AsyncState).EndAccept(ar)
				};
				state.Socket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ServerReadCallback, state);
			}
			catch (Exception ex)
			{
				OnErrorOccurred(ex);
			}
		}

		private void ServerReadCallback(IAsyncResult ar)
		{
			try
			{
				var state = (StateObject)ar.AsyncState;
				var handler = state.Socket;
				if (handler.Connected)
				{
					int read = handler.EndReceive(ar);
					if (read > 0)
					{
						byte[] data = new byte[read];
						Array.Copy(state.Buffer, 0, data, 0, read);
						OnDataArrived(new DataArrivedEventArgs(handler, (IPEndPoint)handler.RemoteEndPoint, data));
						handler.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ServerReadCallback, state);
					}
				}
			}
			catch (Exception ex)
			{
				OnErrorOccurred(ex);
			}
		}

		protected virtual void OnDataArrived(DataArrivedEventArgs e)
		{
			DataArrived?.Invoke(this, e);
		}

		protected virtual void OnErrorOccurred(Exception exception)
		{
			ErrorOccurred?.Invoke(this, new ErrorOccurredEventArgs(exception));
		}

		private async Task DataArrivedHandlerAsync(object sender, DataArrivedEventArgs e)
		{
			try
			{
				var vncServer = (VncServer)sender;
				var message = vncServer.Encoding.GetString(e.Response);

				while (message.Contains(VncCommand.GetScreen))
				{
					clientSocket = e.Socket;
					message = message.Remove(VncCommand.GetScreen);
				}

				if (message == VncCommand.SendScreenSize)
				{
					var screenSizeMessage = $"{VncCommand.ScreenSize}{VncCommand.Separator}{Screen.PrimaryScreen.Bounds.Width}x{Screen.PrimaryScreen.Bounds.Height}";
					await vncServer.SendAsync(e.Socket, screenSizeMessage);
				}
				else if (message.StartsWith($"{VncCommand.KillApp} "))
				{
					ProcessUtils.KillProcesses(message.Substring(8));
				}
				else if (message.IndexOf(VncCommand.Mouse) > Constants.NOT_FOUND)
				{
					await MouseHandler.ProcessMessageAsync(message);
				}
				else if (message.StartsWith(VncCommand.KeyPressed))
				{
					var data = message.Split(' ');
					SendKeys.SendWait(data[1]);
				}
				else if (message.StartsWith(VncCommand.Scrool))
				{
					var values = message.Split(new string[] { $"{VncCommand.Scrool} " }, StringSplitOptions.RemoveEmptyEntries);
					foreach (var value in values)
					{
						var scroolValue = Convert.ToInt32(value);
						// scroolValue < 0 => scrools down
						WinAPI.MouseEvent(WinAPI.MOUSEEVENTF_WHEEL, 0, 0, scroolValue, 0);
					}
				}
				else
				{
					if (!String.IsNullOrEmpty(message))
					{
						var command = message.GetProgramAndParameters();
						var parameters = String.Join(" ", command.Skip(1).Select(param => param.Contains(' ') && !param.StartsWith("\"") ? $"\"{param}\"" : param));
						ProcessUtils.RunProgramOrFile(command[0], parameters);
					}
				}
			}
			catch (Exception ex)
			{
				OnErrorOccurred(ex);
			}
		}
	}
}
