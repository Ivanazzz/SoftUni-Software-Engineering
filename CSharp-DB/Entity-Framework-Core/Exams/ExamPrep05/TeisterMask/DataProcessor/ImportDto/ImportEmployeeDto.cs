namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Common;

    [JsonObject("Employee")]
    public class ImportEmployeeDto
    {
        [JsonProperty("Username")]
        [Required]
        [MinLength(ValidationConstants.EmployeeUsernameMinLength)]
        [MaxLength(ValidationConstants.EmployeeUsernameMaxLength)]
        [RegularExpression(ValidationConstants.EmployeeUsernameRegEx)]
        public string Username { get; set; } = null!;

        [JsonProperty("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [JsonProperty("Phone")]
        [Required]
        [RegularExpression(ValidationConstants.EmployeePhoneRegEx)]
        public string Phone { get; set; } = null!;

        [JsonProperty("Tasks")]
        public int[] TaskIds { get; set; }
    }
}
