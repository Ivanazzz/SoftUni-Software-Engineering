namespace BookingApp.Models.Hotels
{
    using System;

    using Contacts;
    using Models.Bookings.Contracts;
    using Models.Rooms.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        private readonly IRepository<IRoom> rooms;
        private readonly IRepository<IBooking> bookings;

        private Hotel()
        {
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }

        public Hotel(string fullName, int category)
            : this()
        {
            FullName = fullName;
            Category = category;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }    

                fullName = value;
            }
        }

        public int Category
        {
            get
            {
                return category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover
            => TotalAmount();

        public IRepository<IRoom> Rooms => rooms;

        public IRepository<IBooking> Bookings => bookings;

        private double TotalAmount()
        {
            double totalAmount = 0;

            foreach (IBooking booking in Bookings.All())
            {
                totalAmount += Math.Round(booking.ResidenceDuration * booking.Room.PricePerNight, 2);
            }

            return Math.Round(totalAmount, 2);
        }
    }
}
