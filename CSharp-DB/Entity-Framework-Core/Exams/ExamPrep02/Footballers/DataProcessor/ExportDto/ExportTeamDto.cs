namespace Footballers.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Team")]
    public class ExportTeamDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Footballers")]
        public ExportFootballerForTeamDto[] Footballers { get; set; }
    }
}
