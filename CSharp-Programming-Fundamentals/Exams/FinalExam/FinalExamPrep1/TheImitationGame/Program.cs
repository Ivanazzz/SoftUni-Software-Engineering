using System;

namespace TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split('|');
                if (tokens[0] == "Decode")
                {
                    break;
                }

                string action = tokens[0];

                switch (action)
                {
                    case "Move":
                        int numberOfLetters = int.Parse(tokens[1]);
                        message = Move(message, numberOfLetters);
                        break;
                    case "Insert":
                        int index = int.Parse(tokens[1]);
                        string value = tokens[2];

                        message = message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string substring = tokens[1];
                        string replacement = tokens[2];

                        message = message.Replace(substring, replacement);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        private static string Move(string message, int numberOfLetters)
        {
            string stringToMove = message.Substring(0, numberOfLetters);

            message = message.Remove(0, numberOfLetters);
            message += stringToMove;
            return message;
        }
    }
}
