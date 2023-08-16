namespace Boardgames.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Seller")]
    public class ExportSellerDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Website")]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public ExportBoardgameForSellerDto[] Boardgames { get; set; }
    }
}
