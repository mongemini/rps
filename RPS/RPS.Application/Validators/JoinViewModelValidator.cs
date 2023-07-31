using FluentValidation;
using RPS.Application.ViewModel;

namespace RPS.Application.Validators
{
    public class JoinViewModelValidator : AbstractValidator<JoinViewModel>
    {
        public JoinViewModelValidator()
        {
            RuleFor(m => m.GameId).GreaterThan(0);
            RuleFor(m => m.SecondUserName).NotEmpty().MinimumLength(1);
        }
    }
}
