namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            vehicles = new HashSet<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            vehicles.Add(BuildVehicleUsingFactory());
            vehicles.Add(BuildVehicleUsingFactory());

            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (InsufficientFuelException ife)
                {
                    writer.WriteLine(ife.Message);
                }
                catch (InvalidVehicleTypeException ivte)
                {
                    writer.WriteLine(ivte.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            PrintAllVehicles();
        }

        private IVehicle BuildVehicleUsingFactory()
        {
            string[] vehicleArgs = reader
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);

            IVehicle vehicle = vehicleFactory.CreateVehicle(vehicleType, vehicleFuelQuantity, vehicleFuelConsumption);

            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] cmdArgs = reader
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandType = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double arg = double.Parse(cmdArgs[2]);

            IVehicle vehicleToProcess = vehicles
                .FirstOrDefault(v => v.GetType().Name == vehicleType);
            if (vehicleToProcess == null)
            {
                throw new InvalidVehicleTypeException();
            }

            if (commandType == "Drive")
            {
                writer.WriteLine(vehicleToProcess.Drive(arg));
            }
            else if (commandType == "Refuel")
            {
                vehicleToProcess.Refuel(arg);
            }
        }

        private void PrintAllVehicles()
        {
            foreach (IVehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }
    }
}
