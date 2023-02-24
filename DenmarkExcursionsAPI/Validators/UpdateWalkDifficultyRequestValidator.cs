using DenmarkExcursionsAPI.Models.DTO;
using FluentValidation;

namespace DenmarkExcursionsAPI.Validators
{
    public class UpdateWalkDifficultyRequestValidator : AbstractValidator<UpdateWalkDifficultyRequest>
    {
        public UpdateWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
