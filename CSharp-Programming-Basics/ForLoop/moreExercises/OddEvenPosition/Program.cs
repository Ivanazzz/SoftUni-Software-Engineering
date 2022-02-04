using System;

namespace OddEvenPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = 0;
            double oddMax = 0;
            double evenSum = 0;
            double evenMin = 0;
            double evenMax = 0;
            bool isValidOdd = false;
            bool isValidEven = false;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddSum += number;
                    if (i == 1)
                    {
                        isValidOdd = true;
                        oddMin = number;
                        oddMax = number;
                    }
                    else
                    {
                        if (number < oddMin)
                        {
                            oddMin = number;
                        }
                        if (number > oddMax)
                        {
                            oddMax = number;
                        }
                    }
                }
                else
                {
                    evenSum += number;
                    if (i == 2)
                    {
                        isValidEven = true;
                        evenMin = number;
                        evenMax = number;
                    }
                    else
                    {
                        if (number < evenMin)
                        {
                            evenMin = number;
                        }
                        if (number > evenMax)
                        {
                            evenMax = number;
                        }
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:F2},");
            if (isValidOdd)
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
                Console.WriteLine($"OddMax={oddMax:F2},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            Console.WriteLine($"EvenSum={evenSum:F2},");
            if (isValidEven)
            {
                Console.WriteLine($"EvenMin={evenMin:F2},");
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
        }
    }
}
