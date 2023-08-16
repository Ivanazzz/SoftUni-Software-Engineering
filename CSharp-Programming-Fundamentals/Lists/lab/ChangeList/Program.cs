using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<string> command = Console.ReadLine()
                .Split()
                .ToList();

            while(command[0] != "end")
            {
                int element = int.Parse(command[1]);
                if(command[0] == "Delete")
                {
                    numbers.RemoveAll(el => el == element);
                }
                else if(command[0] == "Insert")
                {
                    int position = int.Parse(command[2]);
                    numbers.Insert(position, element);
                }

                command = Console.ReadLine()
                .Split()
                .ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
