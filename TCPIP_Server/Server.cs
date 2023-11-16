﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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

        MessageService Message = new MessageService();
        public void HandleClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
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
                string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Otrzymano: " + data);

                if(Message.Check(data))
                {
                    Message.Send(clientStream);
                }

            }

            tcpClient.Close();
        }
    }
}