using Board.Host.Models.Requests;
using FluentValidation;

namespace Board.Host.Validators
{
    public class UpdateBoardRequestValidator : AbstractValidator<UpdateBoardRequest>
    {
        public UpdateBoardRequestValidator()
        {
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
