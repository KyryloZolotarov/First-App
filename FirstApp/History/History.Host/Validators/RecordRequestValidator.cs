using FluentValidation;
using History.Host.Models.Requests;

namespace History.Host.Validators
{
    public class RecordRequestValidator : AbstractValidator<RecordRequest>
    {
        public RecordRequestValidator()
        {
            RuleFor(h => h.UserId).NotEmpty();
            RuleFor(x => x.Event).NotEmpty();
            RuleFor(a => a.cardId).NotEmpty();
            RuleFor(s => s.DateTime).NotEmpty();
            RuleFor(f => f.Property).NotEmpty();
            RuleFor(g => g.Destination).MaximumLength(30);
            RuleFor(f => f.Origin).MaximumLength(30);
        }
    }
}
