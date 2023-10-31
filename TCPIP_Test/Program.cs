using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCPIP_Test
{
    internal class Program
    {
        static void Main()
        {
            Server serverInicialization = new("127.0.0.1", 8889);
            serverInicialization.Start();         

            while (true)
            {
                TcpClient clientMask = serverInicialization.AcceptTcpClient();
                Thread clientThread = new(() => serverInicialization.HandleClient(clientMask));
                clientThread.Start();
            }
        }
    }
}