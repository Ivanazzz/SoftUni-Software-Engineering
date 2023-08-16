namespace Easter.Models.Dyes
{
    using Contracts;

    public class Dye : IDye
    {
        private const int DYE_POWER_DECREASE_VALUE = 10;

        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get
            {
                return power;
            }
            private set
            {
                if (value < 0)
                {
                    power = 0;
                }

                power = value;
            }
        }

        public bool IsFinished()
            => Power == 0;

        public void Use()
            => Power -= DYE_POWER_DECREASE_VALUE;
    }
}
