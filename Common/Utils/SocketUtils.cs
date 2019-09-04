using System.Net.Sockets;

namespace Common.Utils
{
	public static class SocketUtils
	{
		public static void CloseSocket(Socket socket)
		{
			if (socket != null)
			{
				try
				{
					socket.Shutdown(SocketShutdown.Both);
					socket.Disconnect(false);
				}
				catch { }
				finally
				{
					socket.Close();
				}
			}
		}
	}
}
