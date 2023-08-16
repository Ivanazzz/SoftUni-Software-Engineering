using System;

namespace PasswordGuess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string secretPhrase = "s3cr3t!P@ssw0rd";
            if (password == secretPhrase)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
