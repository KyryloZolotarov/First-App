using FluentValidation;
using Web.Server.Data.Requests;

namespace Web.Server.Validators
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
