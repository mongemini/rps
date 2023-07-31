using MediatR;
using RPS.Contracts.Models;
using RPS.Contracts.Repositories;

namespace RPS.Application.Commands.Games
{
    public class CreateGameHandler : IRequestHandler<CreateGameCommand, Game>
    {
        private readonly IGamesRepository _gameRepository;

        public CreateGameHandler(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public Task<Game> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            return _gameRepository.CreateGameAsync(request.FirstUserName);
        }
    }
}
