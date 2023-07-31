
using RPS.Contracts.Models;

namespace RPS.Contracts.Services
{
    public interface IGamesService
    {
        Task<Game> JoinToGameAsync(int gameId, string userName);

        Task<Game> NextStepAsync(int gameId, int userId, RPSType turn);
    }
}
