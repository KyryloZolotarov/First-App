using FluentValidation;
using ListCard.Data.Requests;

namespace ListCard.Validators
{
    public class ListRequestValidator : AbstractValidator<ListRequest>
    {
        public ListRequestValidator()
        {
            RuleFor(h => h.UserId).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
