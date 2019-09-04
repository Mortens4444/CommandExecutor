using System;
using System.Net;
using System.Net.Sockets;

namespace Common.Network
{
	public class DataArrivedEventArgs : EventArgs
	{
		public DataArrivedEventArgs(Socket socket, IPEndPoint sender, byte[] response)
		{
			Socket = socket;
			Sender = sender;
			Response = response;
		}

		public IPEndPoint Sender { get; private set; }

		public Socket Socket { get; private set; }

		public byte[] Response { get; private set; }
	}
}
