using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPIP_Test
{
    internal class Server
    {
        private TcpListener _listener;
        public Server(string ip, int port)
        {
            _listener = new TcpListener(IPAddress.Parse(ip), port);
        }
        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Serwer jest uruchomiony.");
        }
        public TcpClient AcceptTcpClient()
        {
            return _listener.AcceptTcpClient();
        }

        private readonly MessageService _message = new MessageService();
        public void HandleClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            var buffer = new byte[1024];

            while (true)
            {
                var bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                }
                catch
                {
                    break;
                }
                if (bytesRead == 0)
                {
                    break;
                }
                var data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Otrzymano: " + data);

                if(_message.Check(data))
                {
                    _message.Send(clientStream);
                }

            }

            tcpClient.Close();
        }
    }
}
