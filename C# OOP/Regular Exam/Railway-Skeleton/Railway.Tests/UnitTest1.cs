namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_WithValidName_ShouldSetStationName()
        {
            string stationName = "Central Station";

            var station = new RailwayStation(stationName);

            Assert.AreEqual(stationName, station.Name);
        }

        [Test]
        public void Constructor_WithNullName_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RailwayStation(null));
        }

        [Test]
        public void Constructor_WithEmptyName_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RailwayStation(string.Empty));
        }

        [Test]
        public void NewArrivalOnBoard_WithTrainInfo_ShouldAddTrainToArrivalQueue()
        {
            var station = new RailwayStation("Test Station");
            string trainInfo = "Train123";

            station.NewArrivalOnBoard(trainInfo);

            Assert.Contains(trainInfo, station.ArrivalTrains);
        }

        [Test]
        public void TrainHasArrived_WithCorrectTrainInfo_ShouldMoveTrainToDepartureQueue()
        {
            var station = new RailwayStation("Test Station");
            string trainInfo = "Train123";
            station.NewArrivalOnBoard(trainInfo);

            string result = station.TrainHasArrived(trainInfo);

            Assert.AreEqual($"{trainInfo} is on the platform and will leave in 5 minutes.", result);
            Assert.IsEmpty(station.ArrivalTrains);
            Assert.Contains(trainInfo, station.DepartureTrains);
        }

        [Test]
        public void TrainHasArrived_WithIncorrectTrainInfo_ShouldReturnErrorMessage()
        {
            var station = new RailwayStation("Test Station");
            string trainInfo = "Train123";
            string otherTrainInfo = "Train456";
            station.NewArrivalOnBoard(otherTrainInfo);

            string result = station.TrainHasArrived(trainInfo);

            Assert.AreEqual($"There are other trains to arrive before {trainInfo}.", result);
            Assert.Contains(otherTrainInfo, station.ArrivalTrains);
            Assert.IsEmpty(station.DepartureTrains);
        }

        [Test]
        public void TrainHasLeft_WithCorrectTrainInfo_ShouldRemoveTrainFromDepartureQueue()
        {
            var station = new RailwayStation("Test Station");
            string trainInfo = "Train123";
            station.NewArrivalOnBoard(trainInfo);
            station.TrainHasArrived(trainInfo);

            bool result = station.TrainHasLeft(trainInfo);

            Assert.IsTrue(result);
            Assert.IsEmpty(station.DepartureTrains);
        }

        [Test]
        public void TrainHasLeft_WithIncorrectTrainInfo_ShouldReturnFalse()
        {
            var station = new RailwayStation("Test Station");
            string trainInfo = "Train123";
            string otherTrainInfo = "Train456";
            station.NewArrivalOnBoard(trainInfo);
            station.TrainHasArrived(trainInfo);

            bool result = station.TrainHasLeft(otherTrainInfo);

            Assert.IsFalse(result);
            Assert.Contains(trainInfo, station.DepartureTrains);
        }
    }
}