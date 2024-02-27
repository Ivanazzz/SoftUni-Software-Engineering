using System.ComponentModel.DataAnnotations;

namespace Demo.Attributes
{
    public class IsAdult : ValidationAttribute
    {
        private readonly DateTime minAge = DateTime.Today.AddYears(-18);
        private readonly int adultAge = 18;

        public IsAdult(int age)
        {
            adultAge = age;
            minAge = DateTime.Today.AddYears(age * -1);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && (DateTime)value <= minAge)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
