using Common;
using Common.Messages;
using Common.Vnc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandExecutor
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				var notifyIconInterface = new NotifyIconInterface();
				var vncServer = new VncServer(Constants.VNC_PORT);
				vncServer.ErrorOccurred += VncServer_ErrorOccurred;
				Application.Run();
			}
			catch (Exception ex)
			{
				ErrorBox.Show("CommandExecutor.Main", ex);
			}
		}

		private static async Task VncServer_ErrorOccurred(object sender, ErrorOccurredEventArgs e)
		{
			await Task.Run(() =>
			{
				Debug.WriteLine(e.Exception);
			});
			//ErrorBox.Show("VncServer_ErrorOccurred", e.Exception);
		}
	}
}
