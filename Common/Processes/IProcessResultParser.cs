using System.Diagnostics;

namespace Common.Processes
{
	public interface IProcessResultParser
	{
		void ErrorDataReceived(object sender, DataReceivedEventArgs e);

		void OutputDataReceived(object sender, DataReceivedEventArgs e);
	}
}