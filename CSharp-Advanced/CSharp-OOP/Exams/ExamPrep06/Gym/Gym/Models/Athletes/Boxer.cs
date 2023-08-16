namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int BOXER_STAMINA = 60;
        private const int BOXER_STAMINA_INCREASEMENT = 15;

        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, BOXER_STAMINA)
        {

        }

        public override void Exercise()
            => Stamina += BOXER_STAMINA_INCREASEMENT;
    }
}
