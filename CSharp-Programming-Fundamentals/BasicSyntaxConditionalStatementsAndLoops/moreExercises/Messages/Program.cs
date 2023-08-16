using System;

namespace Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int strLen = int.Parse(Console.ReadLine());
            string strOutput = "";

            for (int i = 0; i < strLen; i++)
            {
                int combination = int.Parse(Console.ReadLine()); 
                int lastDigit = combination % 10;
                char character = ' ';
                switch (lastDigit)
                {
                    case 0:
                        character = ' ';
                        break;
                    case 2:
                        character = combination == 2 ? 'a' : combination == 22 ? 'b' : 'c';
                        break;
                    case 3:
                        character = combination == 3 ? 'd' : combination == 33 ? 'e' : 'f';
                        break;
                    case 4:
                        character = combination == 4 ? 'g' : combination == 44 ? 'h' : 'i';
                        break;
                    case 5:
                        character = combination == 5 ? 'j' : combination == 55 ? 'k' : 'l';
                        break;
                    case 6:
                        character = combination == 6 ? 'm' : combination == 66 ? 'n' : 'o';
                        break;
                    case 7:
                        character = combination == 7 ? 'p' : combination == 77 ? 'q' : combination == 777 ? 'r' : 's';
                        break;
                    case 8:
                        character = combination == 8 ? 't' : combination == 88 ? 'u' : 'v';
                        break;
                    case 9:
                        character = combination == 9 ? 'w' : combination == 99 ? 'x' : combination == 999 ? 'y' : 'z';
                        break;
                }

                strOutput += character;
            }

            Console.WriteLine(strOutput);
        }
    }
}
