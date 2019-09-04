using Common;
using Common.Extensions;
using Common.Messages;
using Common.Mouse;
using Common.Network;
using Common.Utils;
using Common.Vnc;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandSender
{
	public partial class MouseControlForm : Form
	{
		private readonly VncClient vncClient;
		private bool working = true;
		private int expectedImageSize;
		private byte[] rawImageData;

		public MouseControlForm(string ipOrHostname, int width, int height)
		{
			InitializeComponent();
			DoubleBuffered = true;
			vncClient = new VncClient(ipOrHostname, Constants.VNC_PORT)
			{
				ReceiveBufferSize = Constants.IMAGE_SIZE,
				ReceiveTimeout = 1000
			};
			ClientSize = new Size(width, height);
			vncClient.SetNewDataArriveEventHandler(DataArrivedHandler);

			Task.Factory.StartNew(() =>
			{
				while (working)
				{
					try
					{
						vncClient.Send(VncCommand.GetScreen);
						Thread.Sleep(Constants.SCREEN_WAIT_TIME);
					}
					catch (SocketException)
					{
						working = false;
					}
				}
			});
		}

		private void DataArrivedHandler(object sender, DataArrivedEventArgs e)
		{
			var newData = rawImageData == null || rawImageData.Length == 0;
			var vncClient = (VncClient)sender;
			rawImageData = newData ? e.Response : rawImageData.AppendArrays(e.Response);
			var begining = vncClient.Encoding.GetString(rawImageData.Take(21).ToArray());
			if (begining.StartsWith(VncCommand.ImageSize))
			{
				var data = begining.Split(VncCommand.Separator);
				expectedImageSize = Convert.ToInt32(data[1]);
				rawImageData = rawImageData.Skip(VncCommand.ImageSize.Length + 2 + data[1].Length).ToArray();
			}

			if (rawImageData.Length >= expectedImageSize && expectedImageSize > 0)
			{
				try
				{
					var imageBytes = rawImageData.Take(expectedImageSize).ToArray();
					rawImageData = rawImageData.Skip(expectedImageSize).ToArray();
					if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8) // It's a JPEG! Hurray! :)
					{
						var image = ImageUtils.ByteArrayToImage(imageBytes);
						BackgroundImage = image;
					}
					else
					{
						rawImageData = null;
					}
				}
				catch
				{
					rawImageData = null;
				}
			}
		}

		private void MouseControlForm_MouseMove(object sender, MouseEventArgs e)
		{
			Send($"{VncCommand.MouseMove} {e.X} {e.Y}", "MouseControlForm_MouseMove");
		}

		private void MouseControlForm_MouseClick(object sender, MouseEventArgs e)
		{
			SendMouseEvent(VncCommand.MouseClick, e);
		}

		private void MouseControlForm_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SendMouseEvent(VncCommand.MouseDoubleClick, e);
		}

		private void MouseControlForm_MouseDown(object sender, MouseEventArgs e)
		{
			SendMouseEvent(VncCommand.MouseDown, e);
		}

		private void MouseControlForm_MouseUp(object sender, MouseEventArgs e)
		{
			SendMouseEvent(VncCommand.MouseUp, e);
		}

		private void SendMouseEvent(string eventType, MouseEventArgs e)
		{
			var button = ClickButtonProvider.Get(e.Button);
			Send($"{eventType} {button}", "MouseControlForm.SendMouseEvent");
		}

		private void MouseControlForm_Wheel(object sender, MouseEventArgs e)
		{
			Send($"{VncCommand.Scrool} {e.Delta}", "MouseControlForm_Wheel");
		}

		private void MouseControlForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Cursor.Show();
			working = false;
		}

		private void MouseControlForm_MouseLeave(object sender, EventArgs e)
		{
			Cursor.Show();
		}

		private void MouseControlForm_MouseEnter(object sender, EventArgs e)
		{
			Cursor.Hide();
		}

		private void MouseControlForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			Send($"{VncCommand.KeyPressed} {e.KeyChar}", "MouseControlForm_KeyPress");
		}

		private void Send(string message, string caller)
		{
			try
			{
				vncClient.Send(message);
			}
			catch (Exception ex)
			{
				ErrorBox.Show(caller, ex);
			}
		}
	}
}
