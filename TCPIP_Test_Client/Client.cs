﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCPIP_Test
{
    internal class Client
    {
        public static void SendingTrigger(NetworkStream clientStream)
        {
            string message = "TRIGGER";
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientStream.Write(data, 0, data.Length);
        }

        public static void ReceiveTrigger(NetworkStream clientStream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            Console.WriteLine("Odpowiedź od serwera: " + response);
        }
        
    }
}