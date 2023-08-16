using System;

namespace CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            string result = "";
            result = result + firstChar + secondChar + thirdChar;
;
            Console.WriteLine(result);
        }
    }
}
