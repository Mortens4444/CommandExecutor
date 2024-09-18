using Common.Messages;
using Common.Network;
using Common.Processes;
using Common.Vnc;
using LanguageService.Windows.Forms;
using System;
using System.Threading.Tasks;
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
        
		private async Task SendAsync(string message, DataArrivedEventHandler vncClientDataArrived = null)
		{
			try
			{
				var vncClient = new VncClient(cb_Computer.Text, (ushort)nudPort.Value);
				vncClient.DataArrived += vncClientDataArrived;
				await vncClient.SendAsync(message);
			}
			catch (Exception ex)
			{
                Invoke((MethodInvoker)delegate
                {
					ErrorBox.Show("MainForm.Send", ex);
                });
			}
		}

		private async Task SendAndSetCommandAsync(string message, string processName = null)
		{
            await SendAsync(message);
			tb_Application.Text = processName ?? message;
		}

		private async void Btn_Send_Click(object sender, EventArgs e)
		{
            await SendAsync(tb_Command.Text);
		}

		private async void Btn_Shutdown_Click(object sender, EventArgs e)
		{
			await SendAsync("shutdown /c \"Save your work, the computer will shut down.\" /s");
		}

		private async void Btn_ShutdownAbort_Click(object sender, EventArgs e)
		{
            await SendAsync("shutdown /a");
		}

		private async void Btn_Restart_Click(object sender, EventArgs e)
		{
            await SendAsync("shutdown /c \"Save your work, the computer will restart.\" /r");
		}

		private async void Btn_VisitLink_Click(object sender, EventArgs e)
		{
            await SendAsync($"cmd /c start \"{tb_Link.Text}\"");
		}

		private async void Btn_Start_Click(object sender, EventArgs e)
		{
            await SendAsync($"\"{tb_VideoFile.Text}\"");
		}

		private async void Btn_KillApplication_Click(object sender, EventArgs e)
		{
            await SendAsync($"killapp {tb_Application.Text}");
		}

		private async void Btn_CommandPrompt_Click(object sender, EventArgs e)
		{
            await SendAndSetCommandAsync("cmd");
		}

		private async void Btn_Regedit_Click(object sender, EventArgs e)
		{
            await SendAndSetCommandAsync("regedit");
		}

		private async void Btn_Calc_Click(object sender, EventArgs e)
		{
            await SendAndSetCommandAsync("calc", "Calculator");
		}

		private async void Btn_Paint_Click(object sender, EventArgs e)
		{
            await SendAndSetCommandAsync("mspaint");
		}

		private async void Btn_Notepad_Click(object sender, EventArgs e)
		{
            await SendAndSetCommandAsync("notepad");
		}

		private async void Btn_TaskMgr_Click(object sender, EventArgs e)
		{
            await SendAndSetCommandAsync("taskmgr");
		}

		private async void Btn_MouseControl_Click(object sender, EventArgs e)
		{
            await SendAsync(VncCommand.SendScreenSize, VncClient_DataArrived);
		}

		private async Task VncClient_DataArrived(object sender, DataArrivedEventArgs e)
		{
			var message = await VncClient.GetMessageAsync(sender, e);
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
