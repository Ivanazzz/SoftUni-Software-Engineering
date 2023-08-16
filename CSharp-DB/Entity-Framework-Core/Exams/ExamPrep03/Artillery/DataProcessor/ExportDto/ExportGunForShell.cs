namespace Artillery.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject("Gun")]
    public class ExportGunForShell
    {
        [JsonProperty("GunType")]
        public string GunType { get; set; } = null!;

        [JsonProperty("GunWeight")]
        public int GunWeight { get; set; }

        [JsonProperty("BarrelLength")]
        public double BarrelLength { get; set; }

        [JsonProperty("Range")]
        public string Range { get; set; } = null!;
    }
}
