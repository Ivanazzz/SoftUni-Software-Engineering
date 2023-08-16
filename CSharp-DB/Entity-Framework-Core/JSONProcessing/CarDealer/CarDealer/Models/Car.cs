namespace CarDealer.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();    

        public virtual ICollection<PartCar> PartsCars { get; set; } = new HashSet<PartCar>();
    }
}
