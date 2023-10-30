using System;
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
        public static void HandleClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] buffer = new byte[1024];//miejsce na dane
            int bytesRead;

            while (true)
            {
                bytesRead = 0;//zeruje po przeslaniu
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

                if(Validator.Triger(data))
                {
                    Validator.Message(clientStream);
                }

            }

            tcpClient.Close();
        }
    }
}
