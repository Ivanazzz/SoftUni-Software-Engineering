using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UndoRedo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();

            Stack<string> undo = new Stack<string>();
            Stack<string> redo = new Stack<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Add":
                        AddText(tokens[1], text, undo);
                        break;
                    case "Insert":
                        InsertText(int.Parse(tokens[1]), tokens[2], text, undo);
                        break;
                    case "Delete":
                        DeleteText(int.Parse(tokens[1]), int.Parse(tokens[2]), text, undo);
                        break;
                    case "Contains":
                        bool result = IsItContained(tokens[1], text);
                        Console.WriteLine(result);
                        break;
                    case "Undo":
                        Undo(text, undo, redo);
                        break;
                    case "Redo":
                        Redo(text, undo, redo);
                        break;
                    default:
                        Console.WriteLine("Invalid action!");
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void AddText(string value, StringBuilder text, Stack<string> undo)
        {
            text.Append(value);
            Console.WriteLine(text);
            undo.Push(text.ToString());
        }

        private static void InsertText(int index, string part, StringBuilder text, Stack<string> undo)
        {
            if (index >= 0 && index < text.Length)
            {
                text.Insert(index, part);
                Console.WriteLine(text);
                undo.Push(text.ToString());
            }
            else
            {
                Console.WriteLine("Invalid operation!");
            }
        }

        private static void DeleteText(int startIndex, int endIndex, StringBuilder text, Stack<string> undo)
        {
            if (startIndex >= 0 && startIndex < text.Length &&
                endIndex >= 0 && endIndex < text.Length &&
                startIndex < endIndex)
            {
                text.Remove(startIndex, endIndex - startIndex + 1);
                Console.WriteLine(text);
                undo.Push(text.ToString());
            }
            else
            {
                Console.WriteLine("Invalid operation!");
            }
        }

        private static bool IsItContained(string part, StringBuilder text)
        {
            string textAsString = text.ToString();

            if (textAsString.Contains(part))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void Undo(StringBuilder text, Stack<string> undo, Stack<string> redo)
        {
            string textAsString = text.ToString();

            if (undo.Any())
            {
                redo.Push(undo.Pop().ToString());

                if (undo.Any() && text.ToString() != undo.Peek())
                {
                    textAsString = undo.Peek();
                    text = new StringBuilder(textAsString);
                    Console.WriteLine(textAsString);
                }
            }
        }

        private static void Redo(StringBuilder text, Stack<string> undo, Stack<string> redo)
        {
            string textAsString = text.ToString();

            if (redo.Any())
            {
                textAsString = redo.Pop();
                undo.Push(textAsString);
                text = new StringBuilder(textAsString);
                Console.WriteLine(textAsString);
            }
        }
    }
}
