using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplyDividePattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";

            string input = Console.ReadLine();
            string[] demons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();

            for (int i = 0; i < demons.Length; i++)
            {
                string currentDemon = demons[i];
                var healthMatched = Regex.Matches(currentDemon, healthPattern);
                var health = 0;

                foreach (Match match in healthMatched)
                {
                    char currentChar = char.Parse(match.ToString());
                    health += currentChar;
                }

                double damage = 0;
                var damageMatched = Regex.Matches(currentDemon, damagePattern);


                foreach (Match match in damageMatched)
                {
                    double currentDamage = double.Parse(match.ToString());
                    damage += currentDamage;
                }

                var multiplyAndDivivders = Regex.Matches(currentDemon, multiplyDividePattern);

                foreach (Match match in multiplyAndDivivders)
                {
                    char currentOperator = char.Parse(match.ToString());
                    if (currentOperator == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {health} health, {damage:f2} damage");
            }
        }
    }
}
