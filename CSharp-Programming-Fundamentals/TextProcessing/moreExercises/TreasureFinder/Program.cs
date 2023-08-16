using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> key = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "find")
                {
                    break;
                }

                StringBuilder message = new StringBuilder();

                int count = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    int currentCharAsNumber = (int)input[i];

                    if (count == key.Count)
                    {
                        count = 0;
                    }

                    currentCharAsNumber -= key[count];
                    message.Append((char)currentCharAsNumber);

                    count++;
                }

                string messageAsString = message.ToString();
                int startIndexOfTreasure = messageAsString.IndexOf('&');
                int endIndexOfTreasure = messageAsString.LastIndexOf('&');
                string typeOfTreasure = messageAsString.Substring(startIndexOfTreasure + 1, endIndexOfTreasure - startIndexOfTreasure - 1);

                int startIndexOfCoordinates = messageAsString.IndexOf('<');
                int endIndexOfCoordinates = messageAsString.IndexOf('>');
                string coordinates = messageAsString.Substring(startIndexOfCoordinates + 1, endIndexOfCoordinates - startIndexOfCoordinates - 1);

                Console.WriteLine($"Found {typeOfTreasure} at {coordinates}");
            }
        }
    }
}
