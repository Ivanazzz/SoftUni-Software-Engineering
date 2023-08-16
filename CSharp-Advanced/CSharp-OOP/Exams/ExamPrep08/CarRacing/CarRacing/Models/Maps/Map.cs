namespace CarRacing.Models.Maps
{
    using System;

    using Contracts;
    using Racers.Contracts;
    using Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double strictRacingBehaviorMultiplier = 1.2;
            double aggressiveRacingBehaviorMultiplier = 1.1;

            double racerOneRacingBehaviorMultiplier = racerOne.RacingBehavior == "strict"
                ? strictRacingBehaviorMultiplier
                : aggressiveRacingBehaviorMultiplier;
            double racerTwoRacingBehaviorMultiplier = racerTwo.RacingBehavior == "strict"
                ? strictRacingBehaviorMultiplier
                : aggressiveRacingBehaviorMultiplier;

            double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneRacingBehaviorMultiplier;
            double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoRacingBehaviorMultiplier;

            IRacer winner = racerOneChanceOfWinning > racerTwoChanceOfWinning
                ? racerOne
                : racerTwo;

            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }
    }
}
