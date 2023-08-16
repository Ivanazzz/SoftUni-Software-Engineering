namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportPartDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("supplierId")]
        public int SuplierId { get; set; }
    }
}
