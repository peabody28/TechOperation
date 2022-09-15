using FluentValidation;
using repositories.Interfaces;
using TechOperation.Models.User;
using FluentValidation.Results;
using TechOperation.Constants;

namespace TechOperation.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {

        #region [ Dependency -> Repositories ]

        public IUserRepository UserRepository { get; set; }

        public IRoleRepository RoleRepository { get; set; }

        #endregion

        public CreateUserValidator(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;

            RuleFor(model => model)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom(ValidateRole)
                .Custom(ValidateTelegramId)
                .Custom(ValidatePhoneNumber)
                .Custom(ValidateName);
        }

        private void ValidateTelegramId(CreateUserModel model, ValidationContext<CreateUserModel> context)
        {
            if (model.TelegramId.Equals(0))
            {
                context.AddFailure(new ValidationFailure(nameof(model.TelegramId), ValidationApiErrorConstants.TELEGRAM_ID_REQUIRED));
                return;
            }

            var user = UserRepository.Object(model.TelegramId);
            if (user != null)
                context.AddFailure(new ValidationFailure(nameof(model.TelegramId), ValidationApiErrorConstants.USER_ALREADY_EXISTS));
        }

        private void ValidatePhoneNumber(CreateUserModel model, ValidationContext<CreateUserModel> context)
        {
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                context.AddFailure(new ValidationFailure(nameof(model.PhoneNumber), ValidationApiErrorConstants.PHONE_NUMBER_REQUIRED));
                return;
            }

            var user = UserRepository.ObjectByPhone(model.PhoneNumber);
            if (user != null)
                context.AddFailure(new ValidationFailure(nameof(model.PhoneNumber), ValidationApiErrorConstants.USER_ALREADY_EXISTS));
        }

        private void ValidateName(CreateUserModel model, ValidationContext<CreateUserModel> context)
        {
            if(string.IsNullOrEmpty(model.Name))
            {
                context.AddFailure(new ValidationFailure(nameof(model.Name), ValidationApiErrorConstants.NAME_REQUIRED));
                return;
            }

            var user = UserRepository.Object(model.Name);
            if(user != null)
                context.AddFailure(new ValidationFailure(nameof(model.Name), ValidationApiErrorConstants.USER_ALREADY_EXISTS));
        }

        private void ValidateRole(CreateUserModel model, ValidationContext<CreateUserModel> context)
        {
            var role = RoleRepository.Object(model.RoleCode);
            if (role == null)
                context.AddFailure(new ValidationFailure(nameof(model.RoleCode), ValidationApiErrorConstants.ROLE_CODE_INVALID ));
        }
    }
}
