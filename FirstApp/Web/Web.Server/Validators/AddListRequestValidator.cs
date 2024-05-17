using FluentValidation;
using Web.Server.Data.Requests;

namespace Web.Server.Validators
{
    public class AddListRequestValidator : AbstractValidator<AddListRequest>
    {
        public AddListRequestValidator()
        {
            RuleFor(h => h.BoardId).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
