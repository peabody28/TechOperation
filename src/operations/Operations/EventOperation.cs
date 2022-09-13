using entities.Interfaces;
using operations.Interfaces;
using repositories.Interfaces;

namespace operations.Operations
{
    public class EventOperation : IEventOperation
    {
        #region [ Dependency -> Repositories ]

        public IEventRepository EventRepository { get; set; }

        #endregion

        public EventOperation(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }

        public void Confirm(IEvent ev)
        {
            ev.IsConfirmed = true;
            EventRepository.Update(ev);
        }
    }
}
