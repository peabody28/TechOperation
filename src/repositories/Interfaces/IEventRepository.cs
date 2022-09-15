using entities.Interfaces;

namespace repositories.Interfaces
{
    public interface IEventRepository
    {
        IEvent Object(Guid id);

        IEnumerable<IEvent> Collection(string roleCode);

        void Update(IEvent ev);
    }
}
