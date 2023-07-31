
using RPS.Contracts.Models;
using RPS.Contracts.Repositories;
using RPS.Contracts.Services;

namespace RPS.Application.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gameRepository;
        private const int _stepCount = 5;

        public GamesService(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public async Task<Game> JoinToGameAsync(int gameId, string userName)
        {
            var game = await _gameRepository.GetGameAsync(gameId);
            if (game == null)
            {
                throw new Exception("Game not exists.");
            }

            if (IsGameEnded(game))
            {
                throw new Exception("Game is closed.");
            }

            if (game.SecondUser != null)
            {
                throw new Exception("Second user already exists.");
            }

            if ( game.FirstUser.Name == userName)
            {
                throw new Exception("Second user name the same like first user.");
            }

            game.SecondUser = new User { Name = userName };

            return await _gameRepository.UpdateGameAsync(game);
        }

        public async Task<Game> NextStepAsync(int gameId, int userId, RPSType turn)
        {
            var game = await _gameRepository.GetGameAsync(gameId);
            if (game == null)
            {
                throw new Exception("Game not exists.");
            }

            if (IsGameEnded(game))
            {
                throw new Exception("Game is closed.");
            }

            var lastTurn = game.Tournaments.LastOrDefault();

            var isFirstUserStep = game.FirstUser.Id == userId;
            var isSecondUserStep = game.SecondUser.Id == userId;

            if (!(isFirstUserStep || isSecondUserStep))
            {
                throw new Exception("User from other game.");
            }

            
            if (lastTurn == null 
                || (lastTurn.FirstUserResult != RPSType.None && lastTurn.SecondUserResult != RPSType.None))
            {
                Tournament newTurn;
                if (isFirstUserStep)
                    newTurn = new Tournament { FirstUserResult = turn };
                else
                    newTurn = new Tournament { SecondUserResult = turn };
                game.Tournaments.Add(newTurn);
            }
            else
            {
                if (lastTurn.FirstUserResult != RPSType.None && isFirstUserStep)
                {
                    throw new Exception("First user already made choice.");
                }

                if (lastTurn.SecondUserResult != RPSType.None && isSecondUserStep)
                {
                    throw new Exception("Second user already made choice.");
                }

                if (isFirstUserStep)
                    lastTurn.FirstUserResult = turn;
                else
                    lastTurn.SecondUserResult = turn;

                if (lastTurn.FirstUserResult != RPSType.None && lastTurn.SecondUserResult != RPSType.None) 
                {
                    CalcTournament(lastTurn);
                    game.IsClosed = game.Tournaments.Count == _stepCount;
                }
            }

            return await _gameRepository.UpdateGameAsync(game);
        }

        private static bool IsGameEnded(Game game)
        {
            if (game.IsClosed)
                return true;

            if (game.Tournaments.Count < _stepCount)
                return false;

            var lastTournament = game.Tournaments.Last();

            return lastTournament.FirstUserResult != RPSType.None && lastTournament.SecondUserResult != RPSType.None;
        }

        private static void CalcTournament(Tournament step)
        {
            if ((step.FirstUserResult == RPSType.Rock && step.SecondUserResult == RPSType.Scissors)
                || (step.FirstUserResult == RPSType.Paper && step.SecondUserResult == RPSType.Rock)
                || (step.FirstUserResult == RPSType.Scissors && step.SecondUserResult == RPSType.Paper))
                step.Winner = 1;
            else if ((step.SecondUserResult == RPSType.Rock && step.FirstUserResult == RPSType.Scissors)
                || (step.SecondUserResult == RPSType.Paper && step.FirstUserResult == RPSType.Rock)
                || (step.SecondUserResult == RPSType.Scissors && step.FirstUserResult == RPSType.Paper))
                step.Winner = 2;
        }
    }
}
