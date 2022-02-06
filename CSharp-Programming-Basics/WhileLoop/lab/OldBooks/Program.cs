using System;

namespace OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();

            int bookCounter = 0;

            while (true)
            {
                string book = Console.ReadLine();
                if (book == favouriteBook)
                {
                    Console.WriteLine($"You checked {bookCounter} books and found it.");
                    break;
                }
                else if (book == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookCounter} books.");
                    break;
                }
                bookCounter++;
            }
        }
    }
}
