using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCPIP_Test
{
    internal class Client : IDisposable
    {
        private TcpListener _listener;
        private const string messageToServer = "Trigger";

        public Client(string ip, int port)
        {
            _listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public NetworkStream GetStream()
        {
            TcpClient client = _listener.AcceptTcpClient();
            return client.GetStream();
        }
        public void SendingTrigger(NetworkStream clientStream)
        {
            byte[] data = Encoding.ASCII.GetBytes(messageToServer);
            clientStream.Write(data, 0, data.Length);
        }

        public void ReceiveTrigger(NetworkStream clientStream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            Console.WriteLine("Odpowiedź od serwera: " + response);
        }

        public void Dispose()
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener = null;
            }
        }

    }
}
