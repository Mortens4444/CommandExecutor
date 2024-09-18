using Common;
using Common.Messages;
using Common.Network;
using Common.Processes;
using Common.Vnc;
using LanguageService.Windows.Forms;
using System;
using System.Windows.Forms;
using static Common.Vnc.VncServer;

namespace CommandSender
{
	public partial class MainForm : Form
	{
		private readonly string ipAddress;

		public MainForm(string ipAddress = null)
		{
			InitializeComponent();
			Translator.Translate(this);

			this.ipAddress = ipAddress;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(ipAddress))
			{
				var processResultParser = new IpConfigResultParser(cb_Computer);
				ProcessUtils.ExecuteCommand("ipconfig > tmpfile && grep 'IPv4 Address' tmpfile && rm tmpfile", processResultParser);
			}
			else
			{
				cb_Computer.Items.Add(ipAddress);
				cb_Computer.SelectedIndex = 0;
			}
		}

		private void Send(string message, DataArrivedEventHandler vncClientDataArrived = null)
		{
			try
			{
				var vncClient = new VncClient(cb_Computer.Text, (ushort)nudPort.Value);
				vncClient.DataArrived += vncClientDataArrived;
				vncClient.Send(message);
			}
			catch (Exception ex)
			{
				ErrorBox.Show("MainForm.Send", ex);
			}
		}

		private void SendAndSetCommand(string message, string processName = null)
		{
			Send(message);
			tb_Application.Text = processName ?? message;
		}

		private void Btn_Send_Click(object sender, EventArgs e)
		{
			Send(tb_Command.Text);
		}

		private void Btn_Shutdown_Click(object sender, EventArgs e)
		{
			Send("shutdown /c \"Save your work, the computer will shut down.\" /s");
		}

		private void Btn_ShutdownAbort_Click(object sender, EventArgs e)
		{
			Send("shutdown /a");
		}

		private void Btn_Restart_Click(object sender, EventArgs e)
		{
			Send("shutdown /c \"Save your work, the computer will restart.\" /r");
		}

		private void Btn_VisitLink_Click(object sender, EventArgs e)
		{
			Send($"cmd /c start \"{tb_Link.Text}\"");
		}

		private void Btn_Start_Click(object sender, EventArgs e)
		{
			Send($"\"{tb_VideoFile.Text}\"");
		}

		private void Btn_KillApplication_Click(object sender, EventArgs e)
		{
			Send($"killapp {tb_Application.Text}");
		}

		private void Btn_CommandPrompt_Click(object sender, EventArgs e)
		{
			SendAndSetCommand("cmd");
		}

		private void Btn_Regedit_Click(object sender, EventArgs e)
		{
			SendAndSetCommand("regedit");
		}

		private void Btn_Calc_Click(object sender, EventArgs e)
		{
			SendAndSetCommand("calc", "Calculator");
		}

		private void Btn_Paint_Click(object sender, EventArgs e)
		{
			SendAndSetCommand("mspaint");
		}

		private void Btn_Notepad_Click(object sender, EventArgs e)
		{
			SendAndSetCommand("notepad");
		}

		private void Btn_TaskMgr_Click(object sender, EventArgs e)
		{
			SendAndSetCommand("taskmgr");
		}

		private void Btn_MouseControl_Click(object sender, EventArgs e)
		{
			Send(VncCommand.SendScreenSize, VncClient_DataArrived);
		}

		private void VncClient_DataArrived(object sender, DataArrivedEventArgs e)
		{
			var message = VncClient.GetMessage(sender, e);
			if (message.StartsWith(VncCommand.ScreenSize))
			{
				var data = message.Split(VncCommand.Separator, 'x');
				var width = Convert.ToInt32(data[1]);
				var height = Convert.ToInt32(data[2]);

				cb_Computer.Invoke((MethodInvoker)delegate
				{
					var mcf = new MouseControlForm(cb_Computer.Text, (ushort)nudPort.Value, width, height);
					mcf.Show();
				});
			}
		}
	}
}
