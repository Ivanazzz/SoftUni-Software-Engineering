using System;
using System.Collections.Generic;

namespace HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroesProperties = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = heroesProperties[0];
                int hitPoints = int.Parse(heroesProperties[1]);
                int manaPoints = int.Parse(heroesProperties[2]);

                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, new List<int>());
                }

                heroes[name].Add(hitPoints);
                heroes[name].Add(manaPoints);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "CastSpell":
                        CastSpell(tokens[1], int.Parse(tokens[2]), tokens[3], heroes);
                        break;
                    case "TakeDamage":
                        TakeDamage(tokens[1], int.Parse(tokens[2]), tokens[3], heroes);
                        break;
                    case "Recharge":
                        Recharge(tokens[1], int.Parse(tokens[2]), heroes);
                        break;
                    case "Heal":
                        Heal(tokens[1], int.Parse(tokens[2]), heroes);
                        break;
                }
            }

            PrintInfo(heroes);
        }

        private static void CastSpell(string name, int manaNeeded, string spell, Dictionary<string, List<int>> heroes)
        {
            if (heroes[name][1] >= manaNeeded)
            {
                heroes[name][1] -= manaNeeded;
                Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name][1]} MP!");

                return;
            }

            Console.WriteLine($"{name} does not have enough MP to cast {spell}!");  
        }

        private static void TakeDamage(string name, int damage, string attacker, Dictionary<string, List<int>> heroes)
        {
            heroes[name][0] -= damage;
            if (heroes[name][0] <= 0)
            {
                heroes.Remove(name);
                Console.WriteLine($"{name} has been killed by {attacker}!");

                return;
            }

            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name][0]} HP left!");
        }

        private static void Recharge(string name, int amount, Dictionary<string, List<int>> heroes)
        {
            int originalMana = heroes[name][1];
            heroes[name][1] += amount;

            if (heroes[name][1] > 200)
            {
                heroes[name][1] = 200;
            }

            Console.WriteLine($"{name} recharged for {heroes[name][1] - originalMana} MP!");
        }

        private static void Heal(string name, int amount, Dictionary<string, List<int>> heroes)
        {
            int originalHit = heroes[name][0];
            heroes[name][0] += amount;

            if (heroes[name][0] > 100)
            {
                heroes[name][0] = 100;
            }

            Console.WriteLine($"{name} healed for {heroes[name][0] - originalHit} HP!");
        }

        private static void PrintInfo(Dictionary<string, List<int>> heroes)
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }
    }
}
