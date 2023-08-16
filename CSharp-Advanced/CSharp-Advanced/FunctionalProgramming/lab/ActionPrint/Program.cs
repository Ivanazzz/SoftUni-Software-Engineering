using System;

namespace ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = allNames => Console.WriteLine(string.Join(Environment.NewLine, allNames));

            print(names);
        }
    }
}
