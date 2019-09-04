using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommandExecutor
{
	class NotifyIconInterface
	{
		private readonly NotifyIcon notifyIcon;

		public NotifyIconInterface()
		{
			var exitToolStripMenuItem = new ToolStripMenuItem
			{
				Size = new Size(92, 22),
				Text = "Exit"
			};
			exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem_Click);

			var contextMenuStrip = new ContextMenuStrip
			{
				Size = new Size(93, 26)
			};
			contextMenuStrip.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });

			notifyIcon = new NotifyIcon()
			{
				ContextMenuStrip = contextMenuStrip,
				Icon = Properties.Resources.NotifyIcon,
				Text = "Command Executor (VNC Server)",
				Visible = true
			};
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notifyIcon.Icon = null;
			Application.Exit();
		}
	}
}
