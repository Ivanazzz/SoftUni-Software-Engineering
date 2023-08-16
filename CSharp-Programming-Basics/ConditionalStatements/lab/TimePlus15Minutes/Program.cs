using System;

namespace TimePlus15Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += 15;

            if (minutes >= 60)
            {
                hours += 1;
                minutes %= 60;
                if (hours >= 24)
                {
                    hours = 0;
                }
            }

            if (minutes >= 10)
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
        }
    }
}
