using Demo.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class HomeViewModel : IValidatableObject
    {
        [IsBefore("21/02/2024", ErrorMessage = "Date must be before 21/02/2024", DatePurpose = "Something")]
        public DateTime MyDate { get; set; }

        [IsAdult(18, ErrorMessage = "Must be atleast 18 years")]
        public DateTime BirthDate { get; set; }

        public string? Name { get; set; }

        public string? Country { get; set; }

        // We implement the interface IValidatableObject when we have more complex validations of one or more properties
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required");
            }

            if (string.IsNullOrWhiteSpace(Country))
            {
                yield return new ValidationResult("Country is required");
            }

            if (Name == "Pesho" && Country != "BG")
            {
                yield return new ValidationResult("If name is Pesho, Country must be BG");
            }
        }
    }
}
