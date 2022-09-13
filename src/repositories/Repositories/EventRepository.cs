using entities;
using entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class EventRepository : IEventRepository
    {
        private Bank Bank { get; set; }

        public EventRepository(Bank database)
        {
            Bank = database;
        }

        public IEvent Object(string title)
        {
            return Bank.Event.Include(c => c.Role).FirstOrDefault(ev => ev.Title.Equals(title));
        }

        public IEnumerable<IEvent> Collection(string roleCode)
        {
            return Bank.Event.Include(c => c.Role).Where(ev => roleCode != null ? ev.Role.Code.Equals(roleCode) : true).Cast<IEvent>();
        }

        public void Update(IEvent ev)
        {
            Bank.Event.Update(ev as EventEntity);
            Bank.SaveChanges();
        }
    }
}
