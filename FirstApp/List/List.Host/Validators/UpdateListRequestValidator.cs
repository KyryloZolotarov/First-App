using FluentValidation;
using List.Host.Models.Requests;

namespace List.Host.Validators
{
    public class UpdateListRequestValidator : AbstractValidator<UpdateListRequest>
    {
        public UpdateListRequestValidator()
        {
            RuleFor(h => h.UserId);
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
