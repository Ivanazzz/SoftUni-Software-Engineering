namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Rooms.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> models;

        public RoomRepository()
        {
            models = new List<IRoom>();
        }

        public void AddNew(IRoom model)
            => models.Add(model);

        public IReadOnlyCollection<IRoom> All() => models;

        public IRoom Select(string criteria)
            => models.FirstOrDefault(m => m.GetType().Name == criteria);
    }
}
