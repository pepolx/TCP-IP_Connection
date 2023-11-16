using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCPIP_Test
{
    internal class Program
    {
        static void Main()
        {
            Server server = new("127.0.0.1", 8889);
            server.Start();         

            while (true)
            {
                TcpClient clientMask = server.AcceptTcpClient();
                Thread clientThread = new(() => server.HandleClient(clientMask));
                clientThread.Start();
            }
        }
    }
}