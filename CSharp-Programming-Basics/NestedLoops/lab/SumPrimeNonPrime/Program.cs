using System;

namespace SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primeNumbersSum = 0;
            int nonPrimeNumbersSum = 0;

            string command = Console.ReadLine();

            while (command != "stop")
            {
                int number = int.Parse(command);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    if (number == 0)
                    {
                        nonPrimeNumbersSum += number;
                    }
                    else
                    {
                        int counter = 0;
                        for (int i = 1; i <= number; i++)
                        {
                            if (number % i == 0)
                            {
                                counter++;
                            }
                        }

                        if (counter == 2)
                        {
                            primeNumbersSum += number;
                        }
                        else
                        {
                            nonPrimeNumbersSum += number;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeNumbersSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumbersSum}");
        }
    }
}
