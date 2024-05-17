using Card.Host.Models.Requests;
using FluentValidation;

namespace Card.Host.Validators
{
    public class UpdateCardRequestValidator : AbstractValidator<UpdateCardRequest>
    {
        public UpdateCardRequestValidator()
            {
                RuleFor(h => h.Name).MaximumLength(30);
                RuleFor(x => x.Description).MaximumLength(300);
            }
    }
}
