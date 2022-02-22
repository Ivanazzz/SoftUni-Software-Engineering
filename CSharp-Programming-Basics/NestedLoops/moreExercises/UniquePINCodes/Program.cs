using System;

namespace UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumLimit = int.Parse(Console.ReadLine());
            int secondNumLimit = int.Parse(Console.ReadLine());
            int thirdNumLimit = int.Parse(Console.ReadLine());

            for (int firstNumber = 2; firstNumber <= firstNumLimit; firstNumber++)
            {
                if (firstNumber % 2 == 0)
                {
                    for (int secondNumber = 2; secondNumber <= secondNumLimit; secondNumber++)
                    {
                        int counter = 0;
                        for (int j = 1; j <= secondNumLimit; j++)
                        {
                            if (secondNumber % j == 0)
                            {
                                counter++;
                            }
                        }

                        if (counter == 2)
                        {
                            for (int thirdNumber = 2; thirdNumber <= thirdNumLimit; thirdNumber++)
                            {
                                if (thirdNumber % 2 == 0)
                                {
                                    Console.WriteLine($"{firstNumber} {secondNumber} {thirdNumber}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
