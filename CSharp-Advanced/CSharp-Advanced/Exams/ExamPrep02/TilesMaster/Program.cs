using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> locationByTileArea = new Dictionary<int, string>()
            {
                {40, "Sink" },
                {50, "Oven" },
                {60, "Countertop" },
                {70, "Wall" },
            };

            Stack<int> whiteTilesArea = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> greyTilesArea = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> tilesDoneByLocation = new Dictionary<string, int>();

            while (whiteTilesArea.Any() && greyTilesArea.Any())
            {
                if (whiteTilesArea.Peek() == greyTilesArea.Peek())
                {
                    int currentTile = whiteTilesArea.Pop() + greyTilesArea.Dequeue();

                    if (locationByTileArea.ContainsKey(currentTile))
                    {
                        string location = locationByTileArea[currentTile];

                        if (!tilesDoneByLocation.ContainsKey(location))
                        {
                            tilesDoneByLocation.Add(location, 0);
                        }

                        tilesDoneByLocation[location]++;
                    }
                    else
                    {
                        if (!tilesDoneByLocation.ContainsKey("Floor"))
                        {
                            tilesDoneByLocation.Add("Floor", 0);
                        }

                        tilesDoneByLocation["Floor"]++;
                    }
                }
                else
                {
                    int tempWhiteTile = whiteTilesArea.Pop() / 2;
                    whiteTilesArea.Push(tempWhiteTile);
                    greyTilesArea.Enqueue(greyTilesArea.Dequeue());
                }
            }

            tilesDoneByLocation = tilesDoneByLocation
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (whiteTilesArea.Any())
            {
                Console.Write("White tiles left: ");
                Console.WriteLine(String.Join(", ", whiteTilesArea));
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTilesArea.Any())
            {
                Console.Write("Grey tiles left: ");
                Console.WriteLine(String.Join(", ", greyTilesArea));
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var location in tilesDoneByLocation)
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
