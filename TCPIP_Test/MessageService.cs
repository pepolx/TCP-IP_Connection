using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TCPIP_Test
{
    internal class MessageService
    {
        RandomStringGenerator Random = new();
        private const string desiredMessage = "TRIGGER";
        public bool Check(string messageFromClient)
        {
            if (messageFromClient == desiredMessage)
            {
                return true;
            }
            return false;
        }
        public void Send(NetworkStream clientStream)
        {
            Thread.Sleep(1000);
            string response = Random.Letters(15);
            byte[] responseData = Encoding.ASCII.GetBytes(response);
            clientStream.Write(responseData, 0, responseData.Length);
            Console.WriteLine("Wyslano odpowiedź: " + response);
        }
    }
}
