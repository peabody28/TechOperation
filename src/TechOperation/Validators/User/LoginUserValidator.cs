﻿using FluentValidation;
using FluentValidation.Results;
using repositories.Interfaces;
using TechOperation.Constants;
using TechOperation.Models.User;

namespace TechOperation.Validators.User
{
    public class LoginUserValidator : AbstractValidator<LoginUserModel>
    {

        #region [ Dependency -> Repositories ]

        public IUserRepository UserRepository { get; set; }

        #endregion

        public LoginUserValidator(IUserRepository userRepository)
        {
            UserRepository = userRepository;

            RuleFor(model => model)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom(ValidateUser);
        }

        private void ValidateUser(LoginUserModel model, ValidationContext<LoginUserModel> context)
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
