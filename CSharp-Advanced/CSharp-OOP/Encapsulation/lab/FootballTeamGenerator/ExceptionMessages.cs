namespace FootballTeamGenerator
{
    public static class ExceptionMessages
    {
        public const string NameCannotBeNullOrWhitespace = 
            "A name should not be empty.";
        public const string StatsCannotBeLessThanZeroOrGreaterThanOneHundred = 
            "{0} should be between 0 and 100.";
        public const string PlayerIsMissing =
            "Player {0} is not in {1} team.";
        public const string InexistingTeam = 
            "Team {0} does not exist.";
    }
}
