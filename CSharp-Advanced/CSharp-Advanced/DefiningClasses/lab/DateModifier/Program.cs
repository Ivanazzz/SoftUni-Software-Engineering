using System;

namespace DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int result = DateModifier.CalculateDifference(firstDate, secondDate);
            Console.WriteLine(result);
        }
    }
}
