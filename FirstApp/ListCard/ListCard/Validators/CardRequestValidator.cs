using FluentValidation;
using ListCard.Data.Requests;

namespace ListCard.Validators
{
    public class CardRequestValidator : AbstractValidator<CardRequest>
    {
        public CardRequestValidator()
        {
            RuleFor(h => h.Name).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.Priority).NotEmpty();
            RuleFor(x => x.DueDate).NotEmpty();
        }
    }
}
