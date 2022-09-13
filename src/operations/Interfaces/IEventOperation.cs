using entities.Interfaces;

namespace operations.Interfaces
{
    public interface IEventOperation
    {
        void Confirm(IEvent ev);
    }
}
