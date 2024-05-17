using FluentValidation;
using Web.Server.Data.Requests;

namespace Web.Server.Validators
{
    public class AddBoardRequestValidator : AbstractValidator<AddBoardRequest>
    {
        public AddBoardRequestValidator()
        {
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
