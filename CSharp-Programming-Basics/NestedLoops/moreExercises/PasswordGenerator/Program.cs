using System;

namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            char start = 'a';

            for (int firstSymbol = 1; firstSymbol < n; firstSymbol++)
            {
                for (int secondSymbol = 1; secondSymbol < n; secondSymbol++)
                {
                    for (int thirdSymbol = (int)start; thirdSymbol < (int)start + l; thirdSymbol++)
                    {
                        for (int fourthSymbol = (int)start; fourthSymbol < (int)start + l; fourthSymbol++)
                        {
                            for (int fifthSymbol = 1; fifthSymbol <= n; fifthSymbol++)
                            {
                                if (fifthSymbol > firstSymbol && fifthSymbol > secondSymbol)
                                {
                                    Console.Write($"{firstSymbol}{secondSymbol}{(char)thirdSymbol}{(char)fourthSymbol}{fifthSymbol} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
