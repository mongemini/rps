using RPS.Contracts.Models;
using System.Threading.Tasks;

namespace RPS.Contracts.Repositories
{
    public interface IGamesRepository
    {
        Task<Game?> GetGameAsync(int gameId);

        Task<Game> CreateGameAsync(string userName);

        Task<Game> UpdateGameAsync(Game game);

    }
}
