using System;
using System.Windows.Forms;

namespace CommandSender
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var  mainForm = args.Length == 1 ? new MainForm(args[0]) : new MainForm();
			Application.Run(mainForm);
		}
	}
}
