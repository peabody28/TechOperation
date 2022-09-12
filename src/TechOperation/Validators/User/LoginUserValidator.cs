using FluentValidation;
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
                .Custom(ValidateUser);
        }

        private void ValidateUser(LoginUserModel model, ValidationContext<LoginUserModel> context)
        {
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                context.AddFailure(new ValidationFailure(nameof(model.PhoneNumber), ValidationApiErrorConstants.PHONE_NUMBER_REQUIRED));
                return;
            }

            var user = UserRepository.ObjectByPhone(model.PhoneNumber);
            if (user == null)
                context.AddFailure(new ValidationFailure(nameof(model.PhoneNumber), ValidationApiErrorConstants.USER_NOT_EXISTS));
        }
    }
}
