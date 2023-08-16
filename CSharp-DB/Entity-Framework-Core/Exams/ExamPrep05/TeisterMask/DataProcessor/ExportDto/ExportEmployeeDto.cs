namespace TeisterMask.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Employee")]
    public class ExportEmployeeDto
    {
        [JsonProperty("Username")]
        public string Username { get; set; } = null!;

        [JsonProperty("Tasks")]
        public ExportTaskForEmployeeDto[] Tasks { get; set; }
    }
}
