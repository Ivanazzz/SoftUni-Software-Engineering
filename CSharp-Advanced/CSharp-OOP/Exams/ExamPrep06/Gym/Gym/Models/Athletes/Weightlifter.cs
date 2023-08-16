namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int WEIGHTLIFTER_STAMINA = 50;
        private const int WEIGHTLIFTER_STAMINA_INCREASEMENT = 10;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, WEIGHTLIFTER_STAMINA)
        {

        }

        public override void Exercise()
            => Stamina += WEIGHTLIFTER_STAMINA_INCREASEMENT;
    }
}
