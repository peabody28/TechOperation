using FluentValidation;
using FluentValidation.Results;
using repositories.Interfaces;
using TechOperation.Constants;
using TechOperation.Models.User;

namespace TechOperation.Validators.User
{
    public class RequestUsersValidator : AbstractValidator<RequestUsersModel>
    {
        #region [ Dependency -> Repositories ]

        public IRoleRepository RoleRepository { get; set; }

        #endregion

        public RequestUsersValidator(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;

            RuleFor(model => model)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom(ValidateRole);
        }

        private void ValidateRole(RequestUsersModel model, ValidationContext<RequestUsersModel> context)
        {
            if (string.IsNullOrEmpty(model.RoleCode))
                return;

            var role = RoleRepository.Object(model.RoleCode);
            if (role == null)
                context.AddFailure(new ValidationFailure(nameof(model.RoleCode), ValidationApiErrorConstants.ROLE_CODE_INVALID));
        }
    }
}
