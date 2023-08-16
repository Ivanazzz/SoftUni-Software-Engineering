namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Common;

    [JsonObject("Team")]
    public class ImportTeamDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ValidationConstants.TeamNameMinLength)]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        [RegularExpression(ValidationConstants.TeamNameRegEx)]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [MinLength(ValidationConstants.TeamNationalityMinLength)]
        [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
        public string? Nationality { get; set; }

        [JsonProperty("Trophies")]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballerIds { get; set; }
    }
}
