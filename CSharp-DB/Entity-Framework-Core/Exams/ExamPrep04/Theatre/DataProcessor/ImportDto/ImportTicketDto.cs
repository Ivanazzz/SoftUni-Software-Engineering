namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Common;

    [JsonObject("Ticket")]
    public class ImportTicketDto
    {
        [JsonProperty("Price")]
        [Range(typeof(decimal), ValidationConstants.TicketPriceMinValue, ValidationConstants.TicketPriceMaxValue)]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]
        [Range(typeof(sbyte), ValidationConstants.TicketRowNumberMinValue, ValidationConstants.TicketRowNumberMaxValue)]
        public sbyte RowNumber { get; set; }

        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
