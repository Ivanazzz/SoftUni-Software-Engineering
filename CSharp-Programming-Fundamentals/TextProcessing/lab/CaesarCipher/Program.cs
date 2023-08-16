using System;
using System.Text;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            StringBuilder encryptedMessage = new StringBuilder();

            foreach (char ch in message)
            {
                int nextCharNum = (int)ch + 3;
                encryptedMessage.Append((char)nextCharNum);
            }

            Console.WriteLine(encryptedMessage);
        }
    }
}
