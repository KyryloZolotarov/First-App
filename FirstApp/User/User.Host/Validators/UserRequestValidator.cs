using FluentValidation;
using User.Host.Models.UserRequests;

namespace User.Host.Validators
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
