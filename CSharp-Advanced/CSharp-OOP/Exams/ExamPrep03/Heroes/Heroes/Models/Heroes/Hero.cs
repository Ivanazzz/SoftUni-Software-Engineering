namespace Heroes.Models.Heroes
{
    using System;
    using System.Text;
    using Contracts;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                health = value;
            }
        }

        public int Armour
        {
            get
            {
                return armour;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get
            {
                return weapon;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                weapon = value;
            }
        }

        public bool IsAlive 
            => Health > 0;

        public void AddWeapon(IWeapon weapon)
            => Weapon = weapon;

        public void TakeDamage(int points)
        {
            int armourLeft = Armour - points;

            if (armourLeft >= 0)
            {
                Armour = armourLeft;
            }
            else
            {
                Armour = 0;

                int damage = -armourLeft;

                int healthLeft = Health - damage;

                if (healthLeft < 0)
                {
                    Health = 0;
                }
                else
                {
                    Health = healthLeft;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string weaponOutput = Weapon != null ? Weapon.Name : "Unarmed";

            sb.AppendLine($"{this.GetType().Name}: {Name}");
            sb.AppendLine($"--Health: {Health}");
            sb.AppendLine($"--Armour: {Armour}");
            sb.AppendLine($"--Weapon: {weaponOutput}");

            return sb.ToString().Trim();
        }
    }
}
