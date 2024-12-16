using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChatApp.Net.IO
{
    class PacketReader : BinaryReader
    {
        private NetworkStream _ns;

        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }

        public string ReadMessage()
        {
            var length = ReadInt32();
            if (length <= 0) return string.Empty; // Check if the length is valid

            byte[] msgBuffer = new byte[length];
            int totalRead = 0;
            while (totalRead < length)
            {
                int bytesRead = _ns.Read(msgBuffer, totalRead, length - totalRead);
                if (bytesRead == 0) throw new IOException("Connection closed prematurely."); // Handle closed connection
                totalRead += bytesRead;
            }

            return Encoding.UTF8.GetString(msgBuffer);
        }
    }
}
