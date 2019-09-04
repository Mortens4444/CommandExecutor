using Common.Vnc;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Common.Processes
{
	public class IpConfigResultParser : DefaultProcessResultParser
	{
		private readonly ComboBox comboBox;

		public IpConfigResultParser(ComboBox comboBox)
		{
			this.comboBox = comboBox;
		}

		public override void OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (String.IsNullOrEmpty(e.Data))
			{
				return;
			}

			var lines = e.Data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var line in lines)
			{
				var data = e.Data.Split(new[] { VncCommand.Separator }, StringSplitOptions.RemoveEmptyEntries);
				var localIpAddress = data[data.Length - 1].Trim();

				comboBox.Invoke((MethodInvoker)delegate
				{
					comboBox.Items.Add(localIpAddress);
				});
			}
			comboBox.Invoke((MethodInvoker)delegate
			{
				comboBox.SelectedIndex = comboBox.Items.Count - 1;
			});
		}
	}
}
