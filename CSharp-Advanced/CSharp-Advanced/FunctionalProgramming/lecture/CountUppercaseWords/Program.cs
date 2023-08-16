using System;
using System.Linq;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isStartingWithCapital = w => char.IsUpper(w[0]);

            Console.WriteLine(string.Join("\n", words.Where(isStartingWithCapital)));
        }
    }
}
