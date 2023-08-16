using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Bomb> bombs = new List<Bomb>()
            {
                new Bomb("Cherry Bombs", 60, 0),
                new Bomb("Datura Bombs", 40, 0),
                new Bomb("Smoke Decoy Bombs", 120, 0),
            };

            Queue<int> bombEffect = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            bool isValid = false;

            while (bombEffect.Any() && bombCasing.Any())
            {
                int mix = bombCasing.Peek() +bombEffect.Peek();

                if (bombs.Any(x => x.Value == mix))
                {
                    foreach (Bomb bomb in bombs)
                    {
                        if (bomb.Value == mix)
                        {
                            bomb.Count++;
                        }
                    }

                    bombCasing.Pop();
                    bombEffect.Dequeue();

                    if (isReady(bombs))
                    {
                        isValid = true;
                        break;
                    }
                }
                else
                {
                    int temp = bombCasing.Pop() - 5;
                    bombCasing.Push(temp);
                }
            }

            if (isValid)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs)
            {
                Console.WriteLine($"{bomb.Name}: {bomb.Count}");
            }
        }

        private static bool isReady(List<Bomb> bombs)
        {
            foreach (Bomb bomb in bombs)
            {
                if (bomb.Count < 3)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Bomb
    {
        public Bomb(string name, int value, int count)
        {
            Name = name;
            Value = value;
            Count = count;
        }

        public string Name { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
    }
}
