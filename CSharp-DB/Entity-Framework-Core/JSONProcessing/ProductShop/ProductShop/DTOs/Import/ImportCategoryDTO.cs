namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportCategoryDTO
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
