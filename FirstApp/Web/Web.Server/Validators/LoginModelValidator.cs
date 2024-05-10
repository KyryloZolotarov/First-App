using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace Web.Server.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginRequest>
    {
        public LoginModelValidator()
        {
            RuleFor(h => h.Email).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
        }
    }
}
