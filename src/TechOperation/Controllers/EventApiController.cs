using core;
using Microsoft.AspNetCore.Mvc;
using repositories.Interfaces;
using TechOperation.ModelBuilder;
using TechOperation.Models.Event;

namespace TechOperation.Controllers
{
    public class EventApiController : BaseApiController
    {
        #region [ Dependency -> Repositories ]

        private IEventRepository EventRepository { get; set; }

        #endregion

        public EventApiController(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }

        [HttpGet]
        public IEnumerable<EventModel> Events([FromQuery] RequestEventsModel model)
        {
            var events = EventRepository.Collection(model.RoleCode);
            return events.Select(ev => EventModelBuilder.Build(ev));
        }
    }
}
