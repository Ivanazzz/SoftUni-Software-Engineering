namespace Formula1.Models
{
    using System;
    using System.Text;

    using Contracts;
    using Utilities;

    public class Pilot : IPilot
    {
        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        private IFormulaOneCar car;

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(String.Format(ExceptionMessages.InvalidCarForPilot));
                }
                car = value;
            }
        }

        private int numberOfWins;

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        private bool canRace;

        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }


        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot { fullName } has { numberOfWins} wins.");

            return sb.ToString().Trim();
        }
    }
}
