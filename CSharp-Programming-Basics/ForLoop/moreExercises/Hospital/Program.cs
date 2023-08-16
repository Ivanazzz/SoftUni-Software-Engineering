using System;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int treatedPatients = 0;
            int untreatedPatients = 0;
            int doctors = 7;

            for (int day = 1; day <= period; day++)
            {
                int treatedPatientsForTheDay = 0;
                int untreatedPatientsForTheDay = 0;

                int patients = int.Parse(Console.ReadLine());

                if (day % 3 == 0)
                {
                    if (untreatedPatients > treatedPatients)
                    {
                        doctors++;
                    }
                }
                if (patients <= doctors)
                {
                    treatedPatientsForTheDay = patients;
                }
                else
                {
                    treatedPatientsForTheDay = doctors;
                    untreatedPatientsForTheDay = patients - doctors;
                }
                treatedPatients += treatedPatientsForTheDay;
                untreatedPatients += untreatedPatientsForTheDay;
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
