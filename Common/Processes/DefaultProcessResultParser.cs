using Common.Messages;
using System;
using System.Diagnostics;

namespace Common.Processes
{
	public class DefaultProcessResultParser : IProcessResultParser
	{
		public virtual void ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (String.IsNullOrEmpty(e.Data))
			{
				return;
			}

			ErrorBox.Show("Process execution failed", e.Data);
		}

		public virtual void OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (String.IsNullOrEmpty(e.Data))
			{
				return;
			}

			Console.WriteLine(e.Data);
		}
	}
}
