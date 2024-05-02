using FluentValidation;
using ListCard.Data.Requests;

namespace ListCard.Validators
{
    public class UpdateListRequestValidator : AbstractValidator<AddListRequest>
    {
        public UpdateListRequestValidator()
        {
            RuleFor(x => x.Title).MaximumLength(30);
        }
    }
}
