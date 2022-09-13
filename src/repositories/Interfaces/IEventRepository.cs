using entities.Interfaces;

namespace repositories.Interfaces
{
    public interface IEventRepository
    {
        IEvent Object(string title);

        IEnumerable<IEvent> Collection(string roleCode);

        void Update(IEvent ev);
    }
}
