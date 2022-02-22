using System;

namespace SecretDoor_sLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumLimit = int.Parse(Console.ReadLine());
            int secondNumLimit = int.Parse(Console.ReadLine());
            int thirdNumLimit = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= firstNumLimit; firstDigit++)
            {
                if (firstDigit % 2 == 0)
                {
                    for (int secondDigit = 2; secondDigit <= secondNumLimit; secondDigit++)
                    {
                        int counter = 0;
                        for (int num = 1; num <= secondDigit; num++)
                        {
                            if (secondDigit % num == 0)
                            {
                                counter++;
                            }
                        }

                        if (counter == 2)
                        {
                            for (int thirdDigit = 1; thirdDigit <= thirdNumLimit; thirdDigit++)
                            {
                                if (thirdDigit % 2 == 0)
                                {
                                    Console.WriteLine($"{firstDigit} {secondDigit} {thirdDigit}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
