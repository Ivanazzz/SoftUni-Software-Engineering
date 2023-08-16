using System;

namespace UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumbersLimit = int.Parse(Console.ReadLine());
            int secondNumbersLimit = int.Parse(Console.ReadLine());
            int thirdNumbersLimit = int.Parse(Console.ReadLine());

            for (int a = 2; a <= firstNumbersLimit; a++)
            {
                if (a % 2 == 0)
                {
                    for (int b = 2; b <= secondNumbersLimit; b++)
                    {
                        int counter = 0;
                        for (int i = 1; i <= b; i++)
                        {
                            if (b % i == 0)
                            { 
                                counter++;
                            }
                        }
                        if (counter == 2)
                        {
                            for (int c = 2; c <= thirdNumbersLimit; c++)
                            {
                                if (c % 2 == 0)
                                {
                                    Console.WriteLine($"{a} {b} {c}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
