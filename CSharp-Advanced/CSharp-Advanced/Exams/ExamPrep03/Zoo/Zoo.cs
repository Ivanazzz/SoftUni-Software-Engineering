using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (this.Capacity == 0)
            {
                return "The zoo is full.";
            }
            else
            {
                this.Animals.Add(animal);
                this.Capacity--;

                return $"Successfully added {animal.Species} to the zoo.";
            }
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;

            while (this.Animals.FirstOrDefault(x => x.Species == species) != null)
            {
                Animal targetAnimal = this.Animals.FirstOrDefault(x => x.Species == species);
                this.Animals.Remove(targetAnimal);
                count++;
                this.Capacity--;
            }

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsWithCurrentDiet = this.Animals.Where(x => x.Diet == diet).ToList();

            return animalsWithCurrentDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            Animal animalWithCurrentWeight = this.Animals.FirstOrDefault(x => x.Weight == weight);

            return animalWithCurrentWeight;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (Animal animal in Animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength))
            {
                count++;
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
