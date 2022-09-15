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
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom(ValidateEvent)
                .Custom(ValidateIsConfirmed);
        }

        private void ValidateEvent(ConfirmEventModel model, ValidationContext<ConfirmEventModel> context)
        {
            var ev = EventRepository.Object(model.Id);
            if (ev == null)
                context.AddFailure(new ValidationFailure(nameof(model.Id), ValidationApiErrorConstants.EVENT_NOT_FOUND));
        }

        private void ValidateIsConfirmed(ConfirmEventModel model, ValidationContext<ConfirmEventModel> context)
        {
            var ev = EventRepository.Object(model.Id);
            if (ev.IsConfirmed)
                context.AddFailure(new ValidationFailure(nameof(model.Id), ValidationApiErrorConstants.EVENT_ALREADY_CONFIRMED));
        }
    }
}
