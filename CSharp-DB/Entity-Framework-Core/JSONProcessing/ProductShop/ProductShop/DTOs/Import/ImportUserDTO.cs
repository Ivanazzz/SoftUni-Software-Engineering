namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportUserDTO
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
