using entities.Interfaces;
using TechOperation.Models.Event;

namespace TechOperation.ModelBuilder
{
    public class EventModelBuilder
    {
        public static EventModel Build(IEvent ev)
        {
            return new EventModel
            {
                Title = ev.Title,
                RoleCode = ev.Role.Code,
                IsConfirmed = ev.IsConfirmed
            };
        }
    }
}
