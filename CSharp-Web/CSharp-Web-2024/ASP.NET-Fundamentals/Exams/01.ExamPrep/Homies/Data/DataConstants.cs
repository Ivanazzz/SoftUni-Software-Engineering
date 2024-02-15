namespace Homies.Data
{
    public static class DataConstants
    {
        public const int EventNameMinimumLength = 5;
        public const int EventNameMaximumLength = 20;

        public const int EventDescriptionMinimumLength = 15;
        public const int EventDescriptionMaximumLength = 150;

        public const string DateFormat = "yyyy-MM-dd H:mm";

        public const int TypeNameMinimumLength = 5;
        public const int TypeNameMaximumLength = 15;

        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
    }
}
