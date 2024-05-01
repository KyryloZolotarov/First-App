using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace User.Host.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(h => h.Email).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
        }
    }
}
