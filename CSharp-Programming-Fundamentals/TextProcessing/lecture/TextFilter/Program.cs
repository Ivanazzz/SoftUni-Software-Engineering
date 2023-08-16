using System;

namespace TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string bannedWord in bannedWords)
            {
                string replacedWithAsterix = new string ('*', bannedWord.Length);

                text = text.Replace(bannedWord, replacedWithAsterix);
            }

            Console.WriteLine(text);
        }
    }
}
