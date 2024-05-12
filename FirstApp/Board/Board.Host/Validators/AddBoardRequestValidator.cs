using Board.Host.Models.Requests;
using FluentValidation;

namespace Board.Host.Validators
{
    public class AddBoardRequestValidator : AbstractValidator<AddBoardRequest>
    {
        public AddBoardRequestValidator()
        {
            RuleFor(h => h.UserId).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
