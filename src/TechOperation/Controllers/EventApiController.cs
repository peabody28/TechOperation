using core;
using Microsoft.AspNetCore.Mvc;
using repositories.Interfaces;
using TechOperation.ModelBuilder;
using TechOperation.Models.Event;

namespace TechOperation.Controllers
{
    public class EventApiController : BaseApiController
    {
        private IEventRepository EventRepository { get; set; }

        public EventApiController(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }

        [HttpPost]
        public IEnumerable<EventModel> Events(RequestEventsModel model)
        {
            var events = EventRepository.Collection(model.RoleCode);
            return events.Select(ev => EventModelBuilder.Build(ev));
        }
    }
}
