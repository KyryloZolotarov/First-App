using FluentValidation;
using Web.Server.Data.Requests;

namespace Web.Server.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(h => h.FirstName).NotEmpty().MaximumLength(30);
            RuleFor(h => h.LastName).NotEmpty().MaximumLength(30);
            RuleFor(h => h.Email).NotEmpty().MaximumLength(50);
            RuleFor(h => h.Password).NotEmpty().MaximumLength(50);
        }
    }
}
