using FluentValidation;
using RPS.Application.ViewModel;

namespace RPS.Application.Validators
{
    public class UserStepViewModelValidator : AbstractValidator<UserStepViewModel>
    {
        public UserStepViewModelValidator()
        {
            RuleFor(m => m.GameId).GreaterThan(0);
            RuleFor(m => m.UserId).GreaterThan(0);
            RuleFor(m => m.Turn).IsInEnum();
        }
    }
}
