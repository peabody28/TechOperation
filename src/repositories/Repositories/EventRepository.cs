using entities;
using entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class EventRepository : IEventRepository
    {
        private Bank Bank { get; set; }

        public IServiceProvider Container { get; set; }

        public EventRepository(Bank database,IServiceProvider container)
        {
            Bank = database;
            Container = container;
        }

        public IEvent Object(Guid id)
        {
            return Bank.Event.Include(c => c.Role).FirstOrDefault(ev => ev.Id.Equals(id));
        }

        public IEnumerable<IEvent> Collection(string roleCode)
        {
            var events = Bank.Event.Include(c => c.Role).Where(ev => (roleCode != null ? ev.Role.Code.Equals(roleCode) : true) && !ev.IsConfirmed);
            return events;
        }

        public void Update(IEvent ev)
        {
            Bank.Event.Update(ev as EventEntity);
            Bank.SaveChanges();
        }
    }
}
