using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPIP_Test
{
    internal class RandomStringGenerator
    {
        public RandomStringGenerator()
        { 

        }  
        public string Letters(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomCode = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomCode[i] = chars[random.Next(chars.Length)];
            }
            return new string(randomCode);
        }
        public string Chars(int length)
        {
            Random random = new Random();
            string chars = "!@#$%^&*()_+{}|:<>?,./;'[]-=";
            char[] randomCode = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomCode[i] = chars[random.Next(chars.Length)];
            }
            return new string(randomCode);
        }
    }
}
