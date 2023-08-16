using System;

namespace CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(CharacterMultiplier(words[0], words[1]));
        }

        private static int CharacterMultiplier(string firstWord, string secondWord)
        {
            int totalSum = 0;
            string largerWord = firstWord;
            string shorterWord = secondWord;

            if (firstWord.Length < secondWord.Length)
            {
                largerWord = secondWord;
                shorterWord = firstWord;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                totalSum += (int)largerWord[i] * (int)shorterWord[i];
            }

            for (int i = shorterWord.Length; i < largerWord.Length; i++)
            {
                totalSum += (int)largerWord[i];
            }

            return totalSum;
        }
    }
}
