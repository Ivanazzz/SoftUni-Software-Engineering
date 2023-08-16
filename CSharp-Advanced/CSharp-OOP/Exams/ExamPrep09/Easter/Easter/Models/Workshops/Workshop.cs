namespace Easter.Models.Workshops
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Bunnies.Contracts;
    using Dyes.Contracts;
    using Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone() && bunny.Energy > 0)
            {
                List<IDye> dyes = bunny.Dyes.Where(d => !d.IsFinished()).ToList();

                if (dyes.Any())
                {
                    for (int i = 0; i < dyes.Count; i++)
                    {
                        IDye dye = dyes[i];

                        egg.GetColored();
                        bunny.Work();
                        dye.Use();

                        if (dye.IsFinished() || egg.IsDone() || bunny.Energy == 0)
                        {
                            break;
                        }

                        i--;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
