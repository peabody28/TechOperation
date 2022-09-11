using core;
using repositories.Interfaces;
using TechOperation.ModelBuilder;
using TechOperation.Models.Event;
using System.Web.Http;

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
        public IEnumerable<EventModel> Events([FromUri]RequestEventsModel model)
        {
            var events = EventRepository.Collection(model.RoleCode);
            return events.Select(ev => EventModelBuilder.Build(ev));
        }
    }
}
