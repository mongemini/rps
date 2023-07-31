using MediatR;
using RPS.Application.ViewModel;
using RPS.Contracts.Models;

namespace RPS.Application.Commands.Games
{
    public class JoinToGameCommand: IRequest<Game>
    {

        public JoinToGameCommand(JoinViewModel joinData) 
        {
            JoinData = joinData;
        }

        public JoinViewModel JoinData { get; set; }

    }
}
