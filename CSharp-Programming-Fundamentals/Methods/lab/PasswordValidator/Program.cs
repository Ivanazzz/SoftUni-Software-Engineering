using System;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            PasswordValidator(password);
        }

        private static void PasswordValidator(string password)
        {
            bool isBetweenSixAndTenChars = CheckForCharacters(password);
            bool isOnlyLettersAndDigits = CheckForSymbols(password);
            bool haveAtLeastTwoDigits = CheckForDigits(password);
            if (isBetweenSixAndTenChars && isOnlyLettersAndDigits && haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!isBetweenSixAndTenChars)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!isOnlyLettersAndDigits)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!haveAtLeastTwoDigits)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        private static bool CheckForSymbols(string password)
        {
            foreach (char i in password)
            {
                if (!char.IsLetterOrDigit(i))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckForCharacters(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            return false;
        }

        private static bool CheckForDigits(string password)
        {
            int digitsCounter = 0;

            foreach (char i in password)
            {
                if (char.IsDigit(i))
                {
                    digitsCounter++;
                }
            }

            if (digitsCounter >= 2)
            {
                return true;
            }
            return false;
        }
    }
}
