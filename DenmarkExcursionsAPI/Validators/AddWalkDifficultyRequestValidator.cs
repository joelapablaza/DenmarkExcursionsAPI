using DenmarkExcursionsAPI.Repositories;
using FluentValidation;

namespace DenmarkExcursionsAPI.Validators
{
    public class AddWalkDifficultyRequestValidator : AbstractValidator<AddWalkDifficultyRequest>
    {
        public AddWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
