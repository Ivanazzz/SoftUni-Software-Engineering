namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Bookings.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> models;

        public BookingRepository()
        {
            models = new List<IBooking>();
        }

        public void AddNew(IBooking model)
            => models.Add(model);

        public IReadOnlyCollection<IBooking> All() => models;

        public IBooking Select(string criteria)
            => models.FirstOrDefault(m => m.BookingNumber.ToString() == criteria);
    }
}
