using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletrPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locksInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int reward = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksInfo);
            Stack<int> bullets = new Stack<int>(bulletsInfo);

            int usedBullets = 0;

            while (bullets.Any() && locks.Any())
            {
                StartShootingLocks(bullets, locks, ref usedBullets, barrelSize);
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int moneyEarned = reward - (usedBullets * bulletrPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }

        static void StartShootingLocks(Stack<int> bullets, Queue<int> locks, ref int usedBullets, int barrelSize)
        {
            int currentBulletSize = bullets.Pop();
            int currentLockSize = locks.Peek();
            usedBullets++;

            if (currentBulletSize <= currentLockSize)
            {
                locks.Dequeue();
                Console.WriteLine("Bang!");
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            if (usedBullets % barrelSize == 0 && bullets.Any())
            {
                Console.WriteLine("Reloading!");
            }
        }
    }
}
