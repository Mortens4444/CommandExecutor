using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace Common
{
	public static class PortUtils
	{
		private static readonly Random random = new Random(Environment.TickCount);

		public static int GetFreePort()
		{
			int port;
			do
			{
                port = random.Next(1024, UInt16.MaxValue);
			}
			while (!IsPortAvailable(port));
			return port;
		}

		public static bool IsPortAvailable(int port)
		{
			var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
			var tcpConnections = ipGlobalProperties.GetActiveTcpConnections();
			return tcpConnections.All(tcpConnection => tcpConnection.LocalEndPoint.Port != port);
		}
	}
}
