using entities.Interfaces;
using repositories.DtoBuilders;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class EventRepository : IEventRepository
    {
        private PostgresBank Bank { get; set; }

        private EventDtoBuilder EventDtoBuilder { get; set; }

        public IServiceProvider Container { get; set; }

        public EventRepository(PostgresBank database, EventDtoBuilder eventDtoBuilder, IServiceProvider container)
        {
            Bank = database;
            EventDtoBuilder = eventDtoBuilder;
            Container = container;
        }

        public IEvent Object(string title)
        {
            var eventDtoModel = Bank.Event.FirstOrDefault(ev => ev.Title.Equals(title));
            
            return EventDtoBuilder.Build(eventDtoModel);
        }

        public IEnumerable<IEvent> Collection(string roleCode)
        {
            var events = Bank.Event.Where(ev => ( roleCode != null ? ev.RoleCode.Equals(roleCode) : true) && !ev.IsConfirmed);
            return events.Select(ev => EventDtoBuilder.Build(ev));
        }

        public void Update(IEvent ev)
        {
            var eventDtoModel = EventDtoBuilder.Build(ev);
            Bank.Event.Update(eventDtoModel);
            Bank.SaveChanges();
        }
    }
}
