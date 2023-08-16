using System;
using System.Text;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            StringBuilder newPassword = new StringBuilder();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens[0] == "Done")
                {
                    break;
                }

                string action = tokens[0];

                switch (action)
                {
                    case "TakeOdd":
                        for (int i = 1; i < password.Length; i += 2)
                        {
                            newPassword.Append(password[i]);
                        }
                        password = newPassword.ToString();
                        Console.WriteLine(password);

                        break;
                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);

                        string stringToRemove = password.Substring(index, length);
                        password = password.Replace(stringToRemove, "");

                        Console.WriteLine(password);

                        break;
                    case "Substitute":
                        string substring = tokens[1];
                        string substitute = tokens[2];

                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }


                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
