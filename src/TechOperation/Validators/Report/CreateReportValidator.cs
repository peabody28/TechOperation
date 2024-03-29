﻿using FluentValidation;
using FluentValidation.Results;
using repositories.Interfaces;
using TechOperation.Constants;
using TechOperation.Models.Report;

namespace TechOperation.Validators.Report
{
    public class CreateReportValidator : AbstractValidator<CreateReportModel>
    {
        #region [ Dependency -> Repositories ]

        public IUserRepository UserRepository { get; set; }

        #endregion

        public CreateReportValidator(IUserRepository userRepository)
        {
            UserRepository = userRepository;

            RuleFor(model => model)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom(ValidateTelegramId);
        }

        private void ValidateTelegramId(CreateReportModel model, ValidationContext<CreateReportModel> context)
        {
            if (model.TelegramId.Equals(0))
            {
                context.AddFailure(new ValidationFailure(nameof(model.TelegramId), ValidationApiErrorConstants.TELEGRAM_ID_REQUIRED));
                return;
            }

            var user = UserRepository.Object(model.TelegramId);
            if (user == null)
                context.AddFailure(new ValidationFailure(nameof(model.TelegramId), ValidationApiErrorConstants.USER_NOT_EXISTS));
        }
    }
}
