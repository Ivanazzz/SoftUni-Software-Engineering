using System;

namespace ChristmasTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n + 1; i++)
            {
                if (i == 1)
                {
                    string spaces = new string(' ', n + 1);
                    Console.WriteLine($"{spaces}|");
                }
                else
                {
                    string star = new string('*', i - 1);
                    string frontSpace = new string(' ', n - (i - 1));
                    Console.WriteLine($"{frontSpace}{star} | {star}");
                }
            }
        }
    }
}
