using System;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalString = Console.ReadLine();
            string reversedString = "";

            for (int i = originalString.Length - 1; i >= 0; i--)
            {
                reversedString += originalString[i];
            }

            Console.WriteLine(reversedString);
        }
    }
}
