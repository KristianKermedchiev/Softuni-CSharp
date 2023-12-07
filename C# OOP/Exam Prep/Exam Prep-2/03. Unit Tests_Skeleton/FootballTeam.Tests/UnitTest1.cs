using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor()
        {
            var team = new FootballTeam("Levski", 16);
            Assert.AreEqual(team.Name, "Levski");
            Assert.AreEqual(team.Capacity, 16);
            Assert.AreEqual(team.Players.Count, 0);
        }

        [Test]
        public void Test_Name_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 15));
            Assert.Throws<ArgumentException>(() => new FootballTeam(string.Empty, 15));
        }

        [Test]
        public void Test_Capacity_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 12));
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", -15));
        }

        [Test]
        public void Test_Add_New_Player_Method_Throw()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 16, "Goalkeeper");

            for (int i = 1; i  <= 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer("Pesho", i, "Goalkeeper"));
            }

            var expectedResut = team.AddNewPlayer(player);

            Assert.AreEqual(expectedResut, "No more positions available!");
        }

        [Test]
        public void Test_Add_New_Player_Method_Correct()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 16, "Goalkeeper");


            var result =  team.AddNewPlayer(player);

            var expectedResult = $"Added player Pesho in position Goalkeeper with number 16";

            Assert.AreEqual(result, expectedResult);
        }

        [Test]

        public void Test_Pick_Player_Method_Correct()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 16, "Goalkeeper");

            team.AddNewPlayer(player);

            Assert.AreEqual(player, team.PickPlayer("Pesho"));
            Assert.AreEqual(null, team.PickPlayer("Gosho"));

        }

        [Test]

        public void Test_Player_Score_Correct()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 17, "Goalkeeper");
            team.AddNewPlayer(player);

            var expected = team.PlayerScore(17);

            Assert.AreEqual(player.ScoredGoals, 1);

            Assert.AreEqual(expected, "Pesho scored and now has 1 for this season!");

        }

    }
}