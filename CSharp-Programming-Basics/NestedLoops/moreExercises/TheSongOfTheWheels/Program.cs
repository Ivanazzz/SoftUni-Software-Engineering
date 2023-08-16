using System;

namespace TheSongOfTheWheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());

            int counter = 0;
            string password = "No!";
            bool isValid = false;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    if (a < b)
                    {
                        for (int c = 1; c <= 9; c++)
                        {
                            for (int d = 1; d <= 9; d++)
                            {
                                if (c > d)
                                {
                                    if ((a * b) + (c * d) == M)
                                    {
                                        Console.Write($"{a}{b}{c}{d} ");
                                        counter++;

                                        if (counter == 4)
                                        {
                                            isValid = true;
                                            password = $"{a}{b}{c}{d}";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            if (isValid)
            {
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine(password);
            }
        }
    }
}
