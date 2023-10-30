using System.Net.Sockets;
using System.Text;
using TCPIP_Test;

namespace TCPIP_Test_Client
{
    internal class Program
    {
        static void Main()
        {
            using TcpClient client = new("127.0.0.1", 8888);
            using NetworkStream clientStream = client.GetStream();
            while (true)
            {
                Client.SendingTrigger(clientStream);
                Client.ReceiveTrigger(clientStream);
                
                Thread.Sleep(5000);
            }
        }
    }
}