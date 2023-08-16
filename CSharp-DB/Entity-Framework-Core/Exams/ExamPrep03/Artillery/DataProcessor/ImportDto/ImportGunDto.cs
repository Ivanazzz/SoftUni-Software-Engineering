namespace Artillery.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    using Common;

    [JsonObject("Gun")]
    public class ImportGunDto
    {
        [JsonProperty("ManufacturerId")]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        [JsonProperty("GunWeight")]
        [Range(ValidationConstants.GunWeightMinValue, ValidationConstants.GunWeightMaxValue)]
        public int GunWeight { get; set; }

        [JsonProperty("BarrelLength")]
        [Range(ValidationConstants.GunBarrelLengthMinValue, ValidationConstants.GunBarrelLengthMaxValue)]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }

        [JsonProperty("Range")]
        [Range(ValidationConstants.GunRangeMinValue, ValidationConstants.GunRangeMaxValue)]
        public int Range { get; set; }

        [JsonProperty("GunType")]
        [Required]
        public string GunType { get; set; } = null!;

        [JsonProperty("ShellId")]
        [ForeignKey("Shell")]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public List<CountriesIds> Countries { get; set; }
    }

    public class CountriesIds
    {
        public int Id { get; set; }
    }
}
