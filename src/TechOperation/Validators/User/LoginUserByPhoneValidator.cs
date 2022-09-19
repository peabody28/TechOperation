using FluentValidation;
using FluentValidation.Results;
using repositories.Interfaces;
using TechOperation.Constants;
using TechOperation.Models.User;

namespace TechOperation.Validators.User
{
    public class LoginUserByPhoneValidator : AbstractValidator<LoginUserByPhoneModel>
    {

        #region [ Dependency -> Repositories ]

        public IUserRepository UserRepository { get; set; }

        #endregion

        public LoginUserByPhoneValidator(IUserRepository userRepository)
        {
            UserRepository = userRepository;

            RuleFor(model => model)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom(ValidateUser);
        }

        private void ValidateUser(LoginUserByPhoneModel model, ValidationContext<LoginUserByPhoneModel> context)
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
