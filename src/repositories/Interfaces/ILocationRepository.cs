using entities.Interfaces;

namespace repositories.Interfaces
{
    public interface ILocationRepository
    {
        ILocation Create(float latitude, float longitude);
    }
}
