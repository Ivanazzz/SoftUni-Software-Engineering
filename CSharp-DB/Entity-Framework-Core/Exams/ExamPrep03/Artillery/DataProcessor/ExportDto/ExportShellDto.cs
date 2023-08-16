namespace Artillery.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Shell")]
    public class ExportShellDto
    {
        [JsonProperty("ShellWeight")]
        public double ShellWeight { get; set; }

        [JsonProperty("Caliber")]
        public string Caliber { get; set; } = null!;

        [JsonProperty("Guns")]
        public ExportGunForShell[] Guns { get; set; }
    }
}
