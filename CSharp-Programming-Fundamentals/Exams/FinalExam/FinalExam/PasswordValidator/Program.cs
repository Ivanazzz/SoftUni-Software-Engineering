using System;
using System.Linq;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Complete")
                {
                    break;
                }

                string action = tokens[0];

                switch (action)
                {
                    case "Make":
                        string upperOrLower = tokens[1];
                        int index = int.Parse(tokens[2]);

                        if (upperOrLower == "Upper")
                        {
                            char currentChar = Char.ToUpper(password[index]);
                            password = password.Remove(index, 1);
                            password = password.Insert(index, currentChar.ToString());
                        }
                        else
                        {
                            char currentChar = Char.ToLower(password[index]);
                            password = password.Remove(index, 1);
                            password = password.Insert(index, currentChar.ToString());
                        }

                        Console.WriteLine(password);
                        break;
                    case "Insert":
                        int indexToInsert = int.Parse(tokens[1]);
                        string charToInsert = tokens[2];

                        if (indexToInsert >= 0 && indexToInsert < password.Length)
                        {
                            password = password.Insert(indexToInsert, charToInsert);
                            Console.WriteLine(password);
                        }
                        break;
                    case "Replace":
                        char charToReplace = char.Parse(tokens[1]);
                        int value = int.Parse(tokens[2]);

                        if (password.Contains(charToReplace))
                        {
                            int newCharToReplaceAsNumber = (int)charToReplace + value;
                            char newCharToReplace = (char)newCharToReplaceAsNumber;
                            password = password.Replace(charToReplace, newCharToReplace);
                        }
                        Console.WriteLine(password);
                        break;
                    case "Validation":
                        int countOfLettersUppercase = 0;
                        int countOfLettersLowercase = 0;
                        int countOfDigits = 0;
                        bool isValid = true;

                        for (int i = 0; i < password.Length; i++)
                        {
                            char currentChar = password[i];

                            if (Char.IsLetter(currentChar) || Char.IsDigit(currentChar) || currentChar == '_')
                            {
                                if (Char.IsLetter(currentChar))
                                {
                                    if (Char.IsUpper(currentChar))
                                    {
                                        countOfLettersUppercase++;
                                    }
                                    else
                                    {
                                        countOfLettersLowercase++;
                                    }
                                }
                                else if (Char.IsDigit(currentChar))
                                {
                                    countOfDigits++;
                                }
                            }
                            else
                            {
                                isValid = false;
                                break;
                            }
                        }


                        if (password.Length < 8)
                        {
                            Console.WriteLine("Password must be at least 8 characters long!");
                        }
                        if (!isValid)
                        {
                            Console.WriteLine("Password must consist only of letters, digits and _!");
                        }
                        if (countOfLettersUppercase == 0)
                        {
                            Console.WriteLine("Password must consist at least one uppercase letter!");
                        }
                        if (countOfLettersLowercase == 0)
                        {
                            Console.WriteLine("Password must consist at least one lowercase letter!");
                        }
                        if (countOfDigits == 0)
                        {
                            Console.WriteLine("Password must consist at least one digit!");
                        }
                        break;
                }
            }
        }
    }
}
