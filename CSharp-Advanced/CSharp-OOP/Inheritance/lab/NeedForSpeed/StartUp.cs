using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car(200, 100);
            car.Drive(20);

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(170, 200);
            raceMotorcycle.Drive(5);

            SportCar sportCar = new SportCar(300, 160);
            sportCar.Drive(4);
        }
    }
}
