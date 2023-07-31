using MediatR;
using RPS.Application.ViewModel;

namespace RPS.Application.Queries.Games
{
    public class GetGameRequest: IRequest<GameStatisticViewModel>
    {
        public GetGameRequest(int gameId) 
        {
            GameId = gameId;
        } 

        public int GameId { get; set; }
    }
}
