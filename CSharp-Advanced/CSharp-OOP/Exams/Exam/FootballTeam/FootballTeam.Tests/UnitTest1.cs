namespace FootballTeam.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private string footballTeamName = "Liverpool";
        private int footballTeamCapacity = 16;

        private string footballPlayerName = "Neymar";
        private int footballPlayerNumber = 10;
        private string footballPlayerPosition = "Forward";

        [Test]
        public void FootballTeamConstructorShouldInitialize()
        {
           FootballTeam team = new FootballTeam(footballTeamName, footballTeamCapacity);

            Assert.AreEqual(footballTeamName, team.Name);
            Assert.AreEqual(footballTeamCapacity, team.Capacity);
            Assert.AreEqual(0, team.Players.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FootballTeamNameShouldThrowWithNullOrEmptyName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(name, footballTeamCapacity);
            }, "Name cannot be null or empty!");
        }

        [TestCase(14)]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        public void FootballTeamNameShouldThrowWithCapacityLessThan15(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(footballTeamName, capacity);
            }, "Capacity min value = 15");
        }

        [Test]
        public void FootballTeamPlayersShouldWork()
        {
            FootballTeam team = new FootballTeam(footballTeamName, footballTeamCapacity);

            FootballPlayer player = new FootballPlayer(footballPlayerName, footballPlayerNumber, footballPlayerPosition);

            team.AddNewPlayer(player);

            Assert.AreEqual(1, team.Players.Count);
        }

        [Test]
        public void FootballTeamAddNewPlayerShouldWorkWithPlayersLessThanCapacity()
        {
            FootballTeam team = new FootballTeam(footballTeamName, footballTeamCapacity);

            FootballPlayer player = new FootballPlayer(footballPlayerName, footballPlayerNumber, footballPlayerPosition);

            string expectedOutput = $"Added player {footballPlayerName} in position {footballPlayerPosition} with number {footballPlayerNumber}";
            string actualOutput = team.AddNewPlayer(player);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FootballTeamAddNewPlayerShouldThrowsWithPlayersBiggerOrEqualToCapacity()
        {
            FootballTeam team = new FootballTeam(footballTeamName, footballTeamCapacity);

            for (int i = 1; i <= footballTeamCapacity; i++)
            {
                team.AddNewPlayer(new FootballPlayer("i", i, "Goalkeeper"));
            }

            string expectedOutput = "No more positions available!";
            string actualOutput = team.AddNewPlayer(new FootballPlayer(footballPlayerName, footballPlayerNumber, footballPlayerPosition));

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FootballTeamPickPlayerShouldWorkWithExistingPlayer()
        {
            FootballTeam team = new FootballTeam(footballTeamName, footballTeamCapacity);

            FootballPlayer player = new FootballPlayer(footballPlayerName, footballPlayerNumber, footballPlayerPosition);

            team.AddNewPlayer(player);

            FootballPlayer returnedPlayer = team.PickPlayer(footballPlayerName);

            Assert.AreEqual(footballPlayerName, returnedPlayer.Name);
            Assert.AreEqual(footballPlayerNumber, returnedPlayer.PlayerNumber);
            Assert.AreEqual(footballPlayerPosition, returnedPlayer.Position);
        }

        [Test]
        public void FootballTeamPickPlayerShouldWorkWithNonExistantPlayer()
        {
            FootballTeam team = new FootballTeam(footballTeamName, footballTeamCapacity);

            FootballPlayer player = new FootballPlayer(footballPlayerName, footballPlayerNumber, footballPlayerPosition);

            team.AddNewPlayer(player);

            FootballPlayer returnedPlayer = team.PickPlayer("Ronaldo");
            
            Assert.IsNull(returnedPlayer);
        }

        [Test]
        public void FootballTeamPlayerScoreShouldWorkWithExistingPlayer()
        {
            FootballTeam team = new FootballTeam(footballTeamName, footballTeamCapacity);

            FootballPlayer player = new FootballPlayer(footballPlayerName, footballPlayerNumber, footballPlayerPosition);

            team.AddNewPlayer(player);

            string expectedOutput = $"{footballPlayerName} scored and now has 1 for this season!";
            string actualOutput = team.PlayerScore(footballPlayerNumber);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}