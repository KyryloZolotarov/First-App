﻿using FluentValidation;
using ListCard.Data.Requests;

namespace ListCard.Validators
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
