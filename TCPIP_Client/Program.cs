using System.Net.Sockets;
using System.Text;
using TCPIP_Test;

namespace TCPIP_Test_Client
{
    internal class Program
    {
        static void Main()
        {
            using Client clientIni = new("127.0.0.1", 8889);
            using NetworkStream clientStream = clientIni.GetStream();
            while (true)
            {
                clientIni.SendingTrigger(clientStream);
                clientIni.ReceiveTrigger(clientStream);
                
                Thread.Sleep(5000);
            }
        }
    }
}