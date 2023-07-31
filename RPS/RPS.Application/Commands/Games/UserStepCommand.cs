using MediatR;
using RPS.Application.ViewModel;
using RPS.Contracts.Models;

namespace RPS.Application.Commands.Games
{
    public class UserStepCommand: IRequest<Game>
    {
        public UserStepCommand(UserStepViewModel step) 
        {
            Step= step;
        }

        public UserStepViewModel Step { get; set; }
    }
}
