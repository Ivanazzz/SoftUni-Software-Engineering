namespace Gym.Models.Athletes
{
    using System;

    using Athletes.Contracts;
    using Utilities.Messages;

    public abstract class Athlete : IAthlete
    {
        private const int MAX_STAMINA = 100;

        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                fullName = value;
            }
        }

        public string Motivation
        {
            get
            {
                return motivation;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }

                motivation = value;
            }
        }

        public int Stamina
        {
            get 
            { 
                return stamina; 
            }
            protected set 
            {
                if (value > MAX_STAMINA)
                {
                    stamina = MAX_STAMINA;

                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }

                stamina = value; 
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return numberOfMedals;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                numberOfMedals = value;
            }
        }


        public abstract void Exercise();
    }
}
