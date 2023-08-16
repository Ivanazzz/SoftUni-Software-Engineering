using System;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            int countOfWrongPassword = 0;

            string passwordInput = Console.ReadLine();
            while (passwordInput != password)
            {
                countOfWrongPassword++;
                if(countOfWrongPassword == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    Environment.Exit(0);
                }
                Console.WriteLine("Incorrect password. Try again.");
                passwordInput = Console.ReadLine();
                
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}
