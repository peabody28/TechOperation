using core;
using Microsoft.AspNetCore.Mvc;
using operations.Interfaces;
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

        #region [ Dependency -> Operations ]

        public IEventOperation EventOperation { get; set; }

        #endregion

        public EventApiController(IEventRepository eventRepository, IEventOperation eventOperation)
        {
            EventRepository = eventRepository;
            EventOperation = eventOperation;
        }

        [HttpGet]
        public IEnumerable<EventModel> Events([FromQuery] RequestEventsModel model)
        {
            var events = EventRepository.Collection(model.RoleCode);

            return events.Select(ev => EventModelBuilder.Build(ev));
        }

        [HttpPost]
        public HttpResponseMessage Confirm(ConfirmEventModel model)
        {
            var ev = EventRepository.Object(model.Title);

            EventOperation.Confirm(ev);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}



