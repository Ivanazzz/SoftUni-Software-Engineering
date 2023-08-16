using System;

namespace FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                string stringBeforeSpace = input.Substring(0, input.IndexOf(" "));
                string stringAfterSpace = input.Substring(input.IndexOf(" ") + 1);

                long leftNumber = long.Parse(stringBeforeSpace);
                long rightNumber = long.Parse(stringAfterSpace);

                long digitsSum = 0;

                if (leftNumber >= rightNumber)
                {
                    for (long j = Math.Abs(leftNumber); j > 0; digitsSum += j % 10, j /= 10) ;
                }
                else
                {
                    for (long j = Math.Abs(rightNumber); j > 0; digitsSum += j % 10, j /= 10) ;
                }

                Console.WriteLine(digitsSum);
            }
        }
    }
}
