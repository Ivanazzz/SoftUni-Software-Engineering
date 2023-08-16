using System;

namespace NumbersDividedBy3WithoutReminder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 3; i <= 99; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
