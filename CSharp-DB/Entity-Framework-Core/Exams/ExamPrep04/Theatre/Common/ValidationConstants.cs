namespace Theatre.Common
{
    public static class ValidationConstants
    {
        // Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const string TheatreNumberOfHallsMinValue = "1";
        public const string TheatreNumberOfHallsMaxValue = "10";
        public const int TheatreDirectorMinLength = 4;
        public const int TheatreDirectorMaxLength = 30;

        // Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const float PlayRatingMinValue = 0.00f;
        public const float PlayRatingMaxValue = 10.00f;
        public const int PlayDescriptionMaxLength = 700;
        public const int PlayScreenwriterMinLength = 4;
        public const int PlayScreenwriterMaxLength = 30;

        // Cast
        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;
        public const string CastPhoneNumberRegEx =
            @"^\+44-(\d{2})-(\d{3})-(\d{4})$";

        // Ticket
        public const string TicketPriceMinValue = "1.00";
        public const string TicketPriceMaxValue = "100.00";
        public const string TicketRowNumberMinValue = "1";
        public const string TicketRowNumberMaxValue = "10";
    }
}
