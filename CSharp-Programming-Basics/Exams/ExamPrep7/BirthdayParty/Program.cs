using System;

namespace BirthdayParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double cake = rent * 0.2;
            double drinks = cake - (cake * 0.45);
            double entertainer = rent / 3;
            double totalSum = rent + cake + drinks + entertainer;

            Console.WriteLine(totalSum);
        }
    }
}
