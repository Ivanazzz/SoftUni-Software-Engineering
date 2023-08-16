namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Common;

    [JsonObject("Seller")]
    public class ImportSellerDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ValidationConstants.SellerNameMinLength)]
        [MaxLength(ValidationConstants.SellerNameMaxLength)]
        public string Name { get; set; }

        [JsonProperty("Address")]
        [Required]
        [MinLength(ValidationConstants.SellerAddressMinLength)]
        [MaxLength(ValidationConstants.SellerAddressMaxLength)]
        public string? Address { get; set; }

        [JsonProperty("Country")]
        [Required]
        public string? Country { get; set; }

        [JsonProperty("Website")]
        [Required]
        [RegularExpression(ValidationConstants.SellerWebsiteRegEx)]
        public string? Website { get; set; }

        [JsonProperty("Boardgames")]
        public int[] BoardgameIds { get; set; }
    }
}
