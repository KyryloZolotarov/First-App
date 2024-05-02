using FluentValidation;
using ListCard.Data.Requests;

namespace ListCard.Validators
{
    public class UpdateCardRequestValidator : AbstractValidator<AddCardRequest>
    {
        public UpdateCardRequestValidator()
        {
            RuleFor(h => h.Name).MaximumLength(30);
            RuleFor(x => x.Description).MaximumLength(300);
        }
    }
}
