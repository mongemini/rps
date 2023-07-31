
using MediatR;
using RPS.Contracts.Models;

namespace RPS.Application.Commands.Games
{
    public class CreateGameCommand: IRequest<Game>
    {
        public CreateGameCommand(string firstUserName)
        {
            FirstUserName = firstUserName;
        }

        public string FirstUserName { get; set; }
    }
}
