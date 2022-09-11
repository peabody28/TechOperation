using entities.Interfaces;

namespace repositories.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<IEvent> Collection(string roleCode);
    }
}
