using FluentValidation;
using History.Host.Models.Requests;

namespace History.Host.Validators
{
    public class PaginatedRecordsRequestValidator<T> : AbstractValidator<PaginatedRecordsRequest<T>>
        where T : notnull
    {
        public PaginatedRecordsRequestValidator()
        {
            RuleFor(h => h.PageSize).NotEmpty();
            RuleFor(h => h.PageIndex).NotEmpty();
            RuleFor(h => h.Id).NotEmpty();
        }
    }
}
