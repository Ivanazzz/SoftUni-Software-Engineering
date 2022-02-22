using System;

namespace SafePasswordsGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxNumberOfGeneratedPasswords = int.Parse(Console.ReadLine());

            int counter = 0;
            int A = 35;
            int B = 64;

            while (A <= 55)
            {
                while (B <= 96)
                {
                    for (int x = 1; x <= a; x++)
                    {
                        for (int y = 1; y <= b; y++)
                        {
                            Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");
                            counter++;
                            A++;
                            B++;

                            if (counter >= maxNumberOfGeneratedPasswords || x == a && y == b)
                            {
                                return;
                            }

                            if (A > 55)

                            {
                                A = 35;
                            }
                            if (B > 96)
                            {
                                B = 64;
                            }
                        }
                    }
                }
            }
        }
    }
}
