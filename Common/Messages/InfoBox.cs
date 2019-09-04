using System.Windows.Forms;

namespace Common.Messages
{
	public static class InfoBox
	{
		public static void Show(string title, string message)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
		}
	}
}
