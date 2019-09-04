using System.Net.Sockets;

namespace Common.Network
{
	public class StateObject
	{
		public Socket Socket { get; set; }

		public byte[] Buffer { get; set; } = new byte[Constants.MAX_BUFFER_SIZE];
	}
}
