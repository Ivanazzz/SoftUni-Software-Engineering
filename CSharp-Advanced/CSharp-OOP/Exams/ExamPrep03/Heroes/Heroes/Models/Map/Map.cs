namespace Heroes.Models.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knights = new List<Knight>();
            List<Barbarian> barbarians = new List<Barbarian>();

            foreach (IHero player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero type.");
                    }
                }
            }

            bool continueBattle = true;

            while (continueBattle)
            {
                bool allKnightsAreDead = true;
                bool allBarbariansAreDead = true;

                int aliveKnights = 0;
                int aliveBarbarians = 0;

                foreach (Knight knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        aliveKnights++;
                        allKnightsAreDead = false;

                        foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                        {
                            int weaponDamage = knight.Weapon.DoDamage();

                            barbarian.TakeDamage(weaponDamage);
                        }
                    }
                }

                foreach (Barbarian barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        aliveBarbarians++;
                        allBarbariansAreDead = false;

                        foreach (Knight knight in knights.Where(k => k.IsAlive))
                        {
                            int weaponDamage = barbarian.Weapon.DoDamage();

                            knight.TakeDamage(weaponDamage);
                        }
                    }
                }

                if (allKnightsAreDead)
                {
                    int deadBarbarians = barbarians.Count - aliveBarbarians;

                    return $"The barbarians took {deadBarbarians} casualties but won the battle.";
                }
                else if (allBarbariansAreDead)
                {
                    int deadKnights = knights.Count - aliveKnights;

                    return $"The knights took {deadKnights} casualties but won the battle.";
                }
            }

            throw new InvalidOperationException("The map fight logic has a bug!");
        }
    }
}
