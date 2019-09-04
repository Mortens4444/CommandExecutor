using Common.Messages;
using System;
using System.Diagnostics;

namespace Common.Processes
{
	public static class ProcessUtils
	{
		public static void KillProcesses(string processName)
		{
			var processes = Process.GetProcessesByName(processName);
			KillProcesses(processes);
			FreeProcessArrayResources(processes);
		}

		public static void KillProcesses(params Process[] processes)
		{
			for (var i = 0; i < processes.Length; i++)
			{
				KillProcessIfNecessary(processes[i]);
			}
		}

		public static void KillProcessIfNecessary(Process process)
		{
			try
			{
				if ((process != null) && (!process.HasExited))
				{
					process.Kill();
				}
			}
			catch (Exception ex)
			{
				ErrorBox.Show("ProcessUtils.KillProcessIfNecessary", ex);
			}
		}

		public static void FreeProcessArrayResources(params Process[] processes)
		{
			foreach (var process in processes)
			{
				process.Close();
			}
		}

		public static void RunProgramOrFile(string filename, string arguments)
		{
			try
			{
				var ps = Process.Start(new ProcessStartInfo
				{
					FileName = filename,
					Arguments = arguments,
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				ErrorBox.Show("ProcessUtils.RunProgramOrFile", ex);
			}
		}

		public static void ExecuteCommand(string command, IProcessResultParser processResultParser)
		{
			using (var process = new Process())
			{
				process.StartInfo = new ProcessStartInfo
				{
					FileName = "cmd",
					Arguments = $"/C {command}",
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false
				};
				process.ErrorDataReceived += processResultParser.ErrorDataReceived;
				process.OutputDataReceived += processResultParser.OutputDataReceived;
				process.Start();
				process.WaitForExit();
				process.BeginErrorReadLine();
				process.BeginOutputReadLine();
			}
		}
	}
}
