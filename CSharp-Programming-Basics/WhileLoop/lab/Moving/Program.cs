using System;

namespace Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int higth = int.Parse(Console.ReadLine());

            int freeSpace = width * length * higth;
            bool isValid = true;

            string command = Console.ReadLine();

            while (command != "Done")
            {
                int boxes = int.Parse(command);
                freeSpace -= boxes;
                if (freeSpace < 0)
                {
                    isValid = false;
                    break;
                }
                command = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
            }
        }
    }
}
