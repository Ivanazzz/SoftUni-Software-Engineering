using System;

namespace TheMostPowerfulWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mostPowerfulWord = "";
            double mostPowerfulWordPoints = 0;

            while (true)
            {
                double points = 0;
                string word = Console.ReadLine();
                if (word == "End of words")
                {
                    Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {mostPowerfulWordPoints}");
                    return;
                }

                for (int i = 0; i < word.Length; i++)
                {
                    points += (int)word[i];
                }

                if (word[0] == 'a' || word[0] == 'e' || word[0] == 'i' || word[0] == 'o' ||
                    word[0] == 'u' || word[0] == 'y' || word[0] == 'A' || word[0] == 'E' ||
                    word[0] == 'I' || word[0] == 'O' || word[0] == 'U' || word[0] == 'Y')
                {
                    points *= word.Length;
                }
                else
                {
                    points = Math.Floor(points * 1.00 / word.Length);
                }

                if (points > mostPowerfulWordPoints)
                {
                    mostPowerfulWordPoints = points;
                    mostPowerfulWord = word;
                }
            }
        }
    }
}
