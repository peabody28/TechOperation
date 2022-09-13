using entities.Dto;
using entities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using repositories.Interfaces;

namespace repositories.DtoBuilders
{
    public class EventDtoBuilder
    {
        public IRoleRepository RoleRepository { get; set; }

        public IServiceProvider Container { get; set; }

        public EventDtoBuilder(IServiceProvider container, IRoleRepository roleRepository)
        {
            Container = container;
            RoleRepository = roleRepository;
        }

        public IEvent Build(EventDtoModel model)
        {
            var eventEntity = Container.GetRequiredService<IEvent>();
            var roleEntity = RoleRepository.Object(model.RoleCode);

            eventEntity.Id = model.Id;
            eventEntity.Title = model.Title;
            eventEntity.IsConfirmed = model.IsConfirmed;
            eventEntity.Role = roleEntity;

            return eventEntity;
        }

        public EventDtoModel Build(IEvent ev)
        {
            return new EventDtoModel
            {
                Id = ev.Id,
                Title = ev.Title,
                IsConfirmed = ev.IsConfirmed,
                RoleCode = ev.Role.Code
            };
        }
    }
}