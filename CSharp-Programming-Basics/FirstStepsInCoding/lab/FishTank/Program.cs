using System;

namespace FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int aquariumsLenght = int.Parse(Console.ReadLine());
			int aquariumsWidth = int.Parse(Console.ReadLine());
			int aquariumsHeight = int.Parse(Console.ReadLine());
			double occupiedSpacePercentage = double.Parse(Console.ReadLine());

			int aquariumsVolume = aquariumsLenght * aquariumsWidth * aquariumsHeight;
			double aquariumsVolumeLiters = aquariumsVolume * 0.001;
			double occupiedSpace = occupiedSpacePercentage / 100;
			double neededLiters = aquariumsVolumeLiters * (1 - occupiedSpace);

			Console.WriteLine(neededLiters);
		}
    }
}
