using FluentValidation;
using repositories.Interfaces;
using TechOperation.Models.Event;
using FluentValidation.Results;
using TechOperation.Constants;

namespace TechOperation.Validators.Event
{
    public class ConfirmEventValidator : AbstractValidator<ConfirmEventModel>
    {
        #region [ Dependency -> Repositories ]

        public IEventRepository EventRepository { get; set; }

        #endregion

        public ConfirmEventValidator(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;

            RuleFor(model => model)
                .Custom(ValidateEvent);
        }

        private void ValidateEvent(ConfirmEventModel model, ValidationContext<ConfirmEventModel> context)
        {
            var ev = EventRepository.Object(model.Title);
            if (ev == null)
                context.AddFailure(new ValidationFailure(nameof(model.Title), ValidationApiErrorConstants.EVENT_WITH_SPECIFIED_TITLE_NOT_FOUND));
        }
    }
}
