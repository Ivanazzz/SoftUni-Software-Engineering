using System;

namespace CarNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int firstDigit = start; firstDigit <= end; firstDigit++)
            {
                for (int secondDigit = start; secondDigit <= end; secondDigit++)
                {
                    for (int thirdDigit = start; thirdDigit <= end; thirdDigit++)
                    {
                        for (int fourthDigit = start; fourthDigit <= end; fourthDigit++)
                        {
                            if (firstDigit % 2 != 0)
                            {
                                if (fourthDigit % 2 == 0)
                                {
                                    if (firstDigit > fourthDigit)
                                    {
                                        if ((secondDigit + thirdDigit) % 2 == 0)
                                        {
                                            Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (fourthDigit % 2 != 0)
                                {
                                    if (firstDigit > fourthDigit)
                                    {
                                        if ((secondDigit + thirdDigit) % 2 == 0)
                                        {
                                            Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
