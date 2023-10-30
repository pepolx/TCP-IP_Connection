using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCPIP_Test
{
    internal class Program
    {
        static void Main()
        {
            Server server1 = new Server("127.0.0.1", 8888);
            server1.Start();         

            while (true)
            {
                TcpClient client = server1.AcceptTcpClient();
                Thread clientThread = new Thread(() => Server.HandleClient(client));
                clientThread.Start();
            }
        }
    }
}