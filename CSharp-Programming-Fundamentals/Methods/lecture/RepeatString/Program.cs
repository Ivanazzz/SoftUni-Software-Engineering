using System;
using System.Text;

namespace RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());

            string output = RepeatString(input, times);
            Console.WriteLine(output);
        }

        static string RepeatString(string input, int times)
        {
            StringBuilder repeatedInput = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                repeatedInput.Append(input);
            }

            return repeatedInput.ToString();
        }
    }
}
