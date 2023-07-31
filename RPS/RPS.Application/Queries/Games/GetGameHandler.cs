using AutoMapper;
using MediatR;
using RPS.Application.ViewModel;
using RPS.Contracts.Repositories;

namespace RPS.Application.Queries.Games
{
    public class GetGameHandler : IRequestHandler<GetGameRequest, GameStatisticViewModel>
    {
        private readonly IGamesRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetGameHandler(IGamesRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GameStatisticViewModel> Handle(GetGameRequest request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetGameAsync(request.GameId);
            return _mapper.Map<GameStatisticViewModel>(game);
        }
    }
}
