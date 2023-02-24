﻿using DenmarkExcursionsAPI.Models.DTO;
using FluentValidation;

namespace DenmarkExcursionsAPI.Validators
{
    public class UpdateWalkRequestValidator : AbstractValidator<UpdateWalkRequest>
    {
        public UpdateWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
