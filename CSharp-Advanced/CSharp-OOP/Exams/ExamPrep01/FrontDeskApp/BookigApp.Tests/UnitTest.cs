using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private string fullName = "Paradise";
        private int category = 4;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWork()
        {
            Hotel hotel = new Hotel(fullName, category);

            Assert.AreEqual(fullName, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
            Assert.AreEqual(0, hotel.Rooms.Count);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [TestCase("Pulse")]
        [TestCase("very very very very very very very very very very very very long name")]
        public void FullNameShouldSetNameWithValidValue(string name)
        {
            Hotel hotel = new Hotel(name, category);

            Assert.AreEqual(name, hotel.FullName);
        }

        [TestCase(null)]
        [TestCase("   ")]
        public void FullNameShouldThrowWithInalidValue(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(name, category);
            });
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void CategoryShouldSetCategoryWithValidValue(int categoryNumber)
        {
            Hotel hotel = new Hotel(fullName, categoryNumber);

            Assert.AreEqual(categoryNumber, hotel.Category);
        }

        [TestCase(0)]
        [TestCase(6)]
        [TestCase(-8)]
        public void CategoryShouldThrowWithInalidValue(int categoryNumber)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel(fullName, categoryNumber);
            });
        }

        [Test]
        public void TurnoverShouldSuccessWithZeroBookings()
        {
            Hotel hotel = new Hotel(fullName, category);

            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void TurnoverShouldSuccessWithOneBooking()
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(4, 18);
            int adults = 2;
            int children = 1;
            int residenceDuration = 3;
            double budget = 120;

            double expectedTurnover = residenceDuration * room.PricePerNight;

            hotel.AddRoom(room);
            hotel.BookRoom(adults, children, residenceDuration, budget);

            Assert.AreEqual(expectedTurnover, hotel.Turnover);
        }

        [Test]
        public void TurnoverShouldSuccessWithMultipleBookings()
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(4, 18);
            int adults = 2;
            int children = 1;
            int residenceDuration = 3;
            double budget = 120;

            double expectedTurnover = residenceDuration * room.PricePerNight * 2;

            hotel.AddRoom(room);
            hotel.BookRoom(adults, children, residenceDuration, budget);
            hotel.BookRoom(adults, children, residenceDuration, budget);

            Assert.AreEqual(expectedTurnover, hotel.Turnover);
        }

        [Test]
        public void RoomsShouldSuccessWithZeroRooms()
        {
            Hotel hotel = new Hotel(fullName, category);

            Assert.AreEqual(0, hotel.Rooms.Count);
        }

        [Test]
        public void RoomsShouldSuccessWithMultipleRooms()
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room1 = new Room(3, 17);
            Room room2 = new Room(1, 10);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);

            Assert.AreEqual(2, hotel.Rooms.Count);
        }

        [Test]
        public void BookingsShouldSuccessWithZeroBookings()
        {
            Hotel hotel = new Hotel(fullName, category);

            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [Test]
        public void BookingsShouldSuccessWithMultipleBookings()
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(3, 17);
            int adults = 2;
            int children = 0;
            int residenceDuration = 4;
            double budget = 300;

            hotel.AddRoom(room);
            hotel.BookRoom(adults, children, residenceDuration, budget);

            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void AddRoomShouldSuccessWithOneRoom()
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room = new Room(4, 18);

            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void AddRoomShouldSuccessWithMoreThanOneRoom()
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room1 = new Room(4, 18);
            Room room2 = new Room(2, 13);
            Room room3 = new Room(8, 25);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.AreEqual(3, hotel.Rooms.Count);
        }

        [TestCase(2, 1, 5, 100)]
        [TestCase(2, 0, 4, 60)]
        [TestCase(4, 3, 6, 200)]
        public void BookRoomShouldSuccessWithValidData(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room1 = new Room(4, 18);
            Room room2 = new Room(2, 13);
            Room room3 = new Room(8, 25);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            hotel.BookRoom(adults, children, residenceDuration, budget);

            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [TestCase(2, 1, 5, 100)]
        public void BookRoomShouldSuccessWithValidDataButNoRooms(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room1 = new Room(1, 18);

            hotel.AddRoom(room1);

            hotel.BookRoom(adults, children, residenceDuration, budget);

            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [TestCase(0, 1, 5, 100)]
        [TestCase(-4, 0, 4, 60)]
        public void BookRoomShouldThrowWithZeroOrNegativeAdults(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room1 = new Room(4, 18);
            Room room2 = new Room(2, 13);
            Room room3 = new Room(8, 25);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }

        [TestCase(2, -3, 4, 60)]
        public void BookRoomShouldThrowWithNegativeChildren(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room1 = new Room(4, 18);
            Room room2 = new Room(2, 13);
            Room room3 = new Room(8, 25);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }

        [TestCase(2, 1, 0, 100)]
        [TestCase(3, 0, -4, 60)]
        public void BookRoomShouldThrowWithZeroOrNegativeResidenceDuration(int adults, int children, int residenceDuration, double budget)
        {
            Hotel hotel = new Hotel(fullName, category);
            Room room1 = new Room(4, 18);
            Room room2 = new Room(2, 13);
            Room room3 = new Room(8, 25);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }
    }
}