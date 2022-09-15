using entities;
using entities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private Bank Bank { get; set; }

        public IServiceProvider Container { get; set; }

        public LocationRepository(Bank database, IServiceProvider container)
        {
            Bank = database;
            Container = container;
        }

        public ILocation Create(float latitude, float longitude)
        {
            var entity = Container.GetService<ILocation>();
            entity.Id = Guid.NewGuid();
            entity.Latitude = latitude;
            entity.Longitude = longitude;

            var location = Bank.Location.Add(entity as LocationEntity);
            Bank.SaveChanges();

            return location.Entity;
        }
    }
}
