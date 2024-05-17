using FluentValidation;
using List.Host.Models.Requests;

namespace List.Host.Validators
{
    public class AddListRequestValidator : AbstractValidator<AddListRequest>
    {
        public AddListRequestValidator()
        {
            RuleFor(h => h.UserId).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
