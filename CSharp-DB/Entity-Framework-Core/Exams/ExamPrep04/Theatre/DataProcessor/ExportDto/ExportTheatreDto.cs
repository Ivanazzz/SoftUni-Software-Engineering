namespace Theatre.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Theatre")]
    public class ExportTheatreDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Halls")]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("TotalIncome")]
        public decimal TotalIncome { get; set; }

        [JsonProperty("Tickets")]
        public ExportTicketDto[] Tickets { get; set; }
    }
}
