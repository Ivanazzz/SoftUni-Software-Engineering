using System;

namespace BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int openingBrackets = 0;
            int closingBrackets = 0;

            for (int line = 0; line < numberOfLines; line++)
            {
                string input = Console.ReadLine();
                for (int i = 0; i < input.Length; i++)
                {
                    if(input[i] == '(')
                    {
                        openingBrackets++;
                    }
                    else if(input[i] == ')')
                    {
                        closingBrackets++;
                    }

                    if(closingBrackets > openingBrackets)
                    {
                        Console.WriteLine("UNBALANCED");  
                        Environment.Exit(0);
                    }
                }
            }

            if(openingBrackets == closingBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
