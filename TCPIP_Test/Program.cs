using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCPIP_Test
{
    internal class Program
    {
        static void Main()
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888); //serwer localhost
            server.Start();
            Console.WriteLine("Serwer jest uruchomiony.");

           // Server handle = new();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(() => Server.HandleClient(client));
                clientThread.Start();
            }
        }
    }
}