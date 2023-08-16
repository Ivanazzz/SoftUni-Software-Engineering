using System;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isLessOrEqual = (name, length) => name.Length <= length;

            names = names.Where(n => isLessOrEqual(n, length)).ToArray();

            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
