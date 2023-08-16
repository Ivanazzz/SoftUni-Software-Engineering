namespace Theatre.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Ticket")]
    public class ExportTicketDto
    {
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]
        public sbyte RowNumber { get; set; }
    }
}
