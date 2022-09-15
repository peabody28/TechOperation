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
                Id = ev.Id,
                Message = ev.Message,
                RoleCode = ev.Role.Code
            };
        }
    }
}
