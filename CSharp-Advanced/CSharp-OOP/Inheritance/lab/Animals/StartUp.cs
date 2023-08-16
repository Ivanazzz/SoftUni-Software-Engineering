using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StringBuilder animals = new StringBuilder();

            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }

                string[] animalTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalTokens[0];
                int age = int.Parse(animalTokens[1]);
                string gender = string.Empty;

                if (animalTokens.Length > 2)
                {
                    gender = animalTokens[2];
                }

                switch (animalType)
                {
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        animals.AppendLine(cat.ToString());
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        animals.AppendLine(kitten.ToString());
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.AppendLine(tomcat.ToString());
                        break;
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        animals.AppendLine(dog.ToString());
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        animals.AppendLine(frog.ToString());
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }

            Console.WriteLine(animals.ToString().TrimEnd());
        }
    }
}
