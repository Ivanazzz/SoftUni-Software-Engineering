namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportCarDTO
    {
        [JsonProperty("make")]
        public string Make { get; set; } = null!;

        [JsonProperty("model")]
        public string Model { get; set; } = null!;

        [JsonProperty("traveledDistance")]
        public int TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartsId { get; set; } = new HashSet<int>();
    }
}
