namespace SoftUniBazar.Data
{
    public class DataConstants
    {
        public const int AdNameMinimumLength = 5;
        public const int AdNameMaximumLength = 25;

        public const int AdDescriptionMinimumLength = 15;
        public const int AdDescriptionMaximumLength = 250;

        public const string DateFormat = "yyyy-MM-dd H:mm";

        public const int CategoryNameMinimumLength = 3;
        public const int CategoryNameMaximumLength = 15;

        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
    }
}
