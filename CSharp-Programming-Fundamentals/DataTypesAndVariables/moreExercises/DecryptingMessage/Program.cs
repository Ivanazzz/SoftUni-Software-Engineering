using System;

namespace DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int keyValue = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());
            string secretMessage = "";

            for (int i = 0; i < numberOfLines; i++)
            {
                char currentChar = Char.Parse(Console.ReadLine());
                int currentCharValue = (int)currentChar + keyValue;
                secretMessage += (char)currentCharValue;
            }

            Console.WriteLine(secretMessage);
        }
    }
}
