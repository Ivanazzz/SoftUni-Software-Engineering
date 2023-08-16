using System;
using System.Linq;

namespace SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(":|:");
                if (tokens[0] == "Reveal")
                {
                    break;
                }

                string action = tokens[0];

                switch (action)
                {
                    case "InsertSpace":
                        int index = int.Parse(tokens[1]);
                        message = message.Insert(index, " ");
                        break;
                    case "Reverse":
                        string substringToReverse = tokens[1];

                        if (!message.Contains(substringToReverse))
                        {
                            Console.WriteLine("error");
                            continue;
                        }

                        int indexOfSubstring = message.IndexOf(substringToReverse);
                        message = message.Remove(indexOfSubstring, substringToReverse.Length);

                        message = message + string.Join("", substringToReverse.Reverse());
                        break;
                    case "ChangeAll":
                        string substring = tokens[1];
                        string replacement = tokens[2];

                        if (message.Contains(substring))
                        {
                            message = message.Replace(substring, replacement);
                        }
                        break;  
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
