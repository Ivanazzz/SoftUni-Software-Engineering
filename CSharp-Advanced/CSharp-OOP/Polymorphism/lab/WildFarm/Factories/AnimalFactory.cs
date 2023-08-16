namespace WildFarm.Factories
{
    using Exceptions;
    using Factories.Contracts;
    using Models.Animals;
    using Models.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] cmdArgs)
        {
            string type = cmdArgs[0];
            string name = cmdArgs[1];
            double weight = double.Parse(cmdArgs[2]);
            string thirdArg = cmdArgs[3];

            IAnimal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(thirdArg));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(thirdArg));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, thirdArg);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, thirdArg);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, thirdArg, cmdArgs[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, thirdArg, cmdArgs[4]);
            }
            else
            {
                throw new InvalidAnimalTypeException();
            }

            return animal;
        }
    }
}
