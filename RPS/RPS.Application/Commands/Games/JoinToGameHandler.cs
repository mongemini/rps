using MediatR;
using RPS.Contracts.Models;
using RPS.Contracts.Services;

namespace RPS.Application.Commands.Games
{
    public class JoinToGameHandler : IRequestHandler<JoinToGameCommand, Game>
    {
        private readonly IGamesService _gamesService;

        public JoinToGameHandler(IGamesService gamesService)
        {
            _gamesService = gamesService ?? throw new ArgumentNullException(nameof(gamesService));
        }

        public async Task<Game> Handle(JoinToGameCommand request, CancellationToken cancellationToken)
        {
            return await _gamesService.JoinToGameAsync(request.JoinData.GameId, request.JoinData.SecondUserName);
        }
    }
}
