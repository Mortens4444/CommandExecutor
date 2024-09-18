using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Common.Network
{
	public static class MessageSender
	{
        public static bool Send(Socket socket, byte[] bytes)
        {
            int sentBytes = 0;
            if (socket.Connected)
            {
                sentBytes = socket.Send(bytes, bytes.Length, SocketFlags.None);
            }
            return sentBytes == bytes.Length;
        }

        public static async Task<bool> SendAsync(Socket socket, byte[] bytes)
        {
            int sentBytes = 0;
            if (socket.Connected)
            {
                sentBytes = await socket.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
            }
            return sentBytes == bytes.Length;
        }
    }
}
