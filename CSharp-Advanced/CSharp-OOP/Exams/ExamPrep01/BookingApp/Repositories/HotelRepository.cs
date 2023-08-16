namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Hotels.Contacts;

    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> models;

        public HotelRepository()
        {
            models = new List<IHotel>();
        }

        public void AddNew(IHotel model)
            => models.Add(model);

        public IReadOnlyCollection<IHotel> All()
            => models;

        public IHotel Select(string criteria)
            => models.FirstOrDefault(m => m.FullName == criteria);
    }
}
