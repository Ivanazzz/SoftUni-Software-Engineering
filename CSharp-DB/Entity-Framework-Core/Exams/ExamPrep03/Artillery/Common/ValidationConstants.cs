namespace Artillery.Common
{
    public static class ValidationConstants
    {
        // Country
        public const int CountryNameMinLength = 4;
        public const int CountryNameMaxLength = 60;
        public const int CountryArmySizeMinValue = 50_000;
        public const int CountryArmySizeMaxValue = 10_000_000;

        // Manufacturer
        public const int ManufacturerNameMinLength = 4;
        public const int ManufacturerNameMaxLength = 40;
        public const int ManufacturerFoundedMinLength = 10;
        public const int ManufacturerFoundedMaxLength = 100;

        // Shell
        public const int ShellWeightMinValue = 2;
        public const int ShellWeightMaxValue = 1_680;
        public const int ShellCaliberMinLength = 4;
        public const int ShellCaliberMaxLength = 30;

        // Gun
        public const int GunWeightMinValue = 100;
        public const int GunWeightMaxValue = 1_350_000;
        public const double GunBarrelLengthMinValue = 2.00;
        public const double GunBarrelLengthMaxValue = 35.00;
        public const int GunRangeMinValue = 1;
        public const int GunRangeMaxValue = 100_000;
    }
}
