using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;


namespace TCPIP_Test
{
    internal class Listener
    {
        static void Main()
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888); //serwer localhost
            server.Start();
            //server.Stop();
            Console.WriteLine("Serwer jest uruchomiony.");

            while (true) 
            {
                TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(HandleClient); //polecane bylo by dla kazdego klienta byl inny wątek
                clientThread.Start(client);
            }
        }

        static void HandleClient(object client)//pętla co jakis czas <-- TO DO | TryFinaly | Klasa Serwer z Metoda Handle
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

                if (data == "TRIGGER")
                {
                    // symulacja opóźnienia i wysłanie odpowiedzi
                    Thread.Sleep(1000);
                    string response = GenerateRandomString(15);
                    byte[] responseData = Encoding.ASCII.GetBytes(response);
                    clientStream.Write(responseData, 0, responseData.Length);
                    Console.WriteLine("Wyslano odpowiedź: " + response);
                }
            }

            tcpClient.Close();
        }

        static string GenerateRandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //string chars = "!@#$%^&*()_+{}|:"<>?,./;'[]\-=";
            char[] randomCode = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomCode[i] = chars[random.Next(chars.Length)];
            }
            return new string(randomCode);
        }
    }
}
