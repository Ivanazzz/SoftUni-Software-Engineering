namespace BookingApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Bookings;
    using Models.Bookings.Contracts;
    using Models.Hotels;
    using Models.Hotels.Contacts;
    using Models.Rooms;
    using Models.Rooms.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);

            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(DoubleBed)
                && roomTypeName != nameof(Studio)
                && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            room.SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            int people = adults + children;

            if (!hotels.All().Any(h => h.Category == category))
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            List<IHotel> orderedHotels = hotels
                .All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName)
                .ToList();

            foreach (IHotel hotel in orderedHotels)
            {
                List<IRoom> orderedRooms = hotel
                    .Rooms
                    .All()
                    .Where(r => r.PricePerNight > 0)
                    .Where(r => r.BedCapacity >= people)
                    .OrderBy(r => r.BedCapacity)
                    .ToList();

                if (orderedRooms.Any())
                {
                    IRoom room = orderedRooms.First();

                    int bookingNumber = hotel.Bookings.All().Count + 1;
                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);

                    hotel.Bookings.AddNew(booking);

                    return String.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }

            }

            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Any())
            {
                foreach (IBooking booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().Trim();
        }
    }
}
