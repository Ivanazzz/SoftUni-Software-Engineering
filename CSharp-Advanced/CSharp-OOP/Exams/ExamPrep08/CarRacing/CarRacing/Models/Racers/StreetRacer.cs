namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const string STREET_RACER_RACING_BEHAVIOR = "aggressive";
        private const int STREET_RACER_DRIVING_EXPERIENCE = 10;
        private const int STREET_RACER_DRIVING_EXPERIENCE_INCREMENT = 5;

        public StreetRacer(string username, ICar car)
            : base(username, STREET_RACER_RACING_BEHAVIOR, STREET_RACER_DRIVING_EXPERIENCE, car)
        {

        }

        public override void Race()
        {
            base.Race();

            DrivingExperience += STREET_RACER_DRIVING_EXPERIENCE_INCREMENT;
        }
    }
}
