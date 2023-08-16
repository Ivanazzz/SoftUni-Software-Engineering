using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> memory = new Stack<string>();
            memory.Push(string.Empty);
            StringBuilder text = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmdType = cmdArgs[0];

                switch (cmdType)
                {
                    case "1":
                        string valueToAppend = cmdArgs[1];
                        text.Append(valueToAppend);
                        memory.Push(text.ToString());
                        break;
                    case "2":
                        int charactersToRemove = int.Parse(cmdArgs[1]);
                        text = text.Remove(text.Length - charactersToRemove, charactersToRemove);
                        memory.Push(text.ToString());
                        break;
                    case "3":
                        int index = int.Parse(cmdArgs[1]);
                        if (index > 0 && index <= text.Length)
                        {
                            Console.WriteLine(text[index - 1]);
                        }
                        break;
                    case "4":
                        memory.Pop();
                        string previousVersion = memory.Peek();
                        text = new StringBuilder(previousVersion);
                        break;
                }
            }
        }
    }
}
