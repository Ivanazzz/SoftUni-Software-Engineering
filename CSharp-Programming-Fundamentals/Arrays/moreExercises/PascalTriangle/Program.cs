using System;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            for (int row = 1; row <= numberOfRows; row++)
            {
                int[] numbersInRow = new int[numberOfRows];
                for (int column = 1; column <= row; column++)
                {
                    int[] numbersInColumn = new int[column];
                    for (int i = 0; i < numbersInColumn.Length; i++)
                    {
                        if(i == 0 || i == numbersInColumn.Length - 1)
                        {
                            numbersInColumn[i] = 1;
                        }
                        else
                        {
                            numbersInColumn[i] = numbersInRow[i] + numbersInRow[i - 1];
                        }
                    }
                    numbersInRow = numbersInColumn;
                }
                Console.WriteLine(string.Join(' ', numbersInRow));
            }
        }
    }
}
