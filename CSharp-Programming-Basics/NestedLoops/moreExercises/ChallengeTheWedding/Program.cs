using System;

namespace ChallengeTheWedding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int maxTables = int.Parse(Console.ReadLine());

            for (int man = 1; man <= men; man++)
            {
                for (int woman = 1; woman <= women; woman++)
                {
                    Console.Write($"({man} <-> {woman}) ");
                    maxTables--;
                    if (maxTables == 0)
                    {
                        return;
                    }

                }
            }
        }
    }
}
