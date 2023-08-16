using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string textInput = Console.ReadLine();

            List<char> letters = new List<char>();

            for (int i = 0; i < textInput.Length; i++)
            {
                letters.Add(textInput[i]);
            }

            string textOutput = "";

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                int currentNumber = numbers[i];

                while(currentNumber != 0)
                {
                    sum += currentNumber % 10;
                    currentNumber /= 10;
                }

                if(sum > letters.Count - 1)
                {
                    sum -= letters.Count;
                }

                for (int j = 0; j < letters.Count; j++)
                {
                    if(j == sum)
                    {
                        textOutput += letters[j];
                        letters.RemoveAt(j);
                        break;
                    }
                }
            }

            Console.WriteLine(textOutput);
        }
    }
}
