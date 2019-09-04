using Common.Messages;
using Common.Network;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Common.Vnc.VncServer;

namespace Common.Vnc
{
	public class VncClient : Socket
	{
		public ushort ListenerPortOfServer { get; set; }
		public event DataArrivedEventHandler DataArrived;
		public Encoding Encoding = Encoding.UTF8;
		private readonly string serverHost = null;

		public VncClient(string serverHost, ushort listenerPort)
			: base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
		{
			ListenerPortOfServer = listenerPort;
			this.serverHost = serverHost;

			ReceiveTimeout = Constants.SOCKET_CONNECTION_TIMEOUT;
			SendTimeout = Constants.SOCKET_CONNECTION_TIMEOUT;
			SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, Constants.MAX_BUFFER_SIZE);
			SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, Constants.MAX_BUFFER_SIZE);

			LingerState = new LingerOption(true, 1);
			NoDelay = true;
			DontFragment = true;

			var result = BeginConnect(this.serverHost, ListenerPortOfServer, null, null);
			bool success = result.AsyncWaitHandle.WaitOne(Constants.SOCKET_CONNECTION_TIMEOUT, true);

			if (!success)
			{
				ErrorBox.Show("Unable to connect", "Check if VNC server is running, check the service port and the firewall settings");
			}
			else
			{
				DataArrived += new DataArrivedEventHandler(DataArrivedHandler);
				Task.Factory.StartNew(() => { Receiver(); });
			}
		}

		public bool Send(string message)
		{
			return SendBytes(Encoding.GetBytes(message));
		}

		public bool SendBytes(byte[] bytes)
		{
			return MessageSender.Send(this, bytes);
		}

		protected virtual void OnDataArrived(DataArrivedEventArgs e)
		{
			DataArrived?.Invoke(this, e);
		}

		public void SetNewDataArriveEventHandler(DataArrivedEventHandler dataArrivedEventHandler)
		{
			if (dataArrivedEventHandler != null)
			{
				DataArrived -= DataArrivedHandler;
				DataArrived += dataArrivedEventHandler;
			}
		}

		public void DataArrivedHandler(object sender, DataArrivedEventArgs e)
		{
			var message = GetMessage(sender, e);
			switch (message)
			{
				case "Unknown command":
					ErrorBox.Show("Command execution error", "Server could not recognize the sent command");
					break;
				default:
					ErrorBox.Show("Unknown message arrived", "Server sent an unexpected message");
					break;
			}
		}

		public static string GetMessage(object sender, DataArrivedEventArgs e)
		{
			var vncClient = (VncClient)sender;
			return vncClient.Encoding.GetString(e.Response);
		}

		private void Receiver()
		{
			try
			{
				while (Connected)
				{
					if (Available > 0)
					{
						Thread.Sleep(100);
						var readable = Available;

						var receiveBuffer = new byte[readable];
						var readBytes = Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
						if (readBytes > 0)
						{
							var s = new string(Encoding.GetChars(receiveBuffer, 0, readBytes));
							OnDataArrived(new DataArrivedEventArgs(this, (IPEndPoint)RemoteEndPoint, receiveBuffer));
						}
					}
					Thread.Sleep(1);
				}
			}
			catch (SocketException) { }
		}
	}
}
