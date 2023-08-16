namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string PROFESSIONAL_RACER_RACING_BEHAVIOR = "strict";
        private const int PROFESSIONAL_RACER_DRIVING_EXPERIENCE = 30;
        private const int PROFESSIONAL_RACER_DRIVING_EXPERIENCE_INCREMENT = 10;

        public ProfessionalRacer(string username, ICar car) 
            : base(username, PROFESSIONAL_RACER_RACING_BEHAVIOR, PROFESSIONAL_RACER_DRIVING_EXPERIENCE, car)
        {

        }

        public override void Race()
        {
            base.Race();

            DrivingExperience += PROFESSIONAL_RACER_DRIVING_EXPERIENCE_INCREMENT;
        }
    }
}
