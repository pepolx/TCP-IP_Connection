﻿using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCPIP_Test
{
    internal class Program
    {
        static void Main()
        {
            Server serverInicialization = new("127.0.0.1", 8888);
            serverInicialization.Start();         

            while (true)
            {
                TcpClient client = serverInicialization.AcceptTcpClient();
                Thread clientThread = new(() => serverInicialization.HandleClient(client));
                clientThread.Start();
            }
        }
    }
}