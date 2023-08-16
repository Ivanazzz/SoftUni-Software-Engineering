using System;

namespace EasterEggsBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstsPlayerEggsCount = int.Parse(Console.ReadLine());
            int secondsPlayerEggsCount = int.Parse(Console.ReadLine());

            bool isValid = true;

            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                if (command == "one")
                {
                    secondsPlayerEggsCount--;
                }
                else if (command == "two")
                {
                    firstsPlayerEggsCount--;
                }

                if (firstsPlayerEggsCount == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {secondsPlayerEggsCount} eggs left.");
                    isValid = false;
                    break;
                }
                else if (secondsPlayerEggsCount == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {firstsPlayerEggsCount} eggs left.");
                    isValid = false;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine($"Player one has {firstsPlayerEggsCount} eggs left.");
                Console.WriteLine($"Player two has {secondsPlayerEggsCount} eggs left.");
            }
        }
    }
}
