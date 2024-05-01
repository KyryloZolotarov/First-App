using FluentValidation;
using List.Host.Models.Requests;

namespace List.Host.Validators
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
