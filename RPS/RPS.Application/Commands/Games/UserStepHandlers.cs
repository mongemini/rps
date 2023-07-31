using MediatR;
using RPS.Contracts.Models;
using RPS.Contracts.Services;

namespace RPS.Application.Commands.Games
{
    public class UserStepHandlers : IRequestHandler<UserStepCommand, Game>
    {
        private readonly IGamesService _gamesService;

        public UserStepHandlers( IGamesService gamesService)
        {
            _gamesService = gamesService ?? throw new ArgumentNullException(nameof(gamesService));
        }

        public async Task<Game> Handle(UserStepCommand request, CancellationToken cancellationToken)
        {
            return await _gamesService.NextStepAsync(request.Step.GameId, request.Step.UserId, request.Step.Turn);
        }
    }
}
