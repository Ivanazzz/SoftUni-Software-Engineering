namespace TeisterMask.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Task")]
    public class ExportTaskForEmployeeDto
    {
        [JsonProperty("TaskName")]
        public string Name { get; set; } = null!;

        [JsonProperty("OpenDate")]
        public string OpenDate { get; set; } = null!;

        [JsonProperty("DueDate")]
        public string DueDate { get; set; } = null!;

        [JsonProperty("LabelType")]
        public string LabelType { get; set; } = null!;

        [JsonProperty("ExecutionType")]
        public string ExecutionType { get; set; } = null!;
    }
}
