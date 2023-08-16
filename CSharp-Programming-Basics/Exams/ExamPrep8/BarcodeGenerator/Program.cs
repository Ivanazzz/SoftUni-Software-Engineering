using System;

namespace BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int firstStart = start % 10;
            start /= 10;
            int secondStart = start % 10;
            start /= 10;
            int thirdStart = start % 10;
            start /= 10;
            int fourthStart = start % 10;

            int firstEnd = end % 10;
            end /= 10;
            int secondEnd = end % 10;
            end /= 10;
            int thirdEnd = end % 10;
            end /= 10;
            int fourthEnd = end % 10;

            for (int a = fourthStart; a <= fourthEnd; a++)
            {
                for (int b = thirdStart; b <= thirdEnd; b++)
                {
                    for (int c = secondStart; c <= secondEnd; c++)
                    {
                        for (int d = firstStart; d <= firstEnd; d++)
                        {
                            if ((a % 2 != 0) && (b % 2 != 0) && (c % 2 != 0) && (d % 2 != 0))
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
