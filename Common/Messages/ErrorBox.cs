using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common.Messages
{
	public static class ErrorBox
	{
		public static void Show(string title, string message)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		public static void Show(string title, Exception ex)
		{
			MessageBox.Show(ex.Message, $"{title} - {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		public static void ShowLastWin32Error(string title)
		{
			Show(title, new Win32Exception(Marshal.GetLastWin32Error()));
		}
	}
}
