using Microsoft.EntityFrameworkCore;
using RPS.Contracts.Models;
using RPS.Contracts.Repositories;


namespace RPS.Infrastructure.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        public async Task<Game> CreateGameAsync(string userName)
        {
            using var context = new GamesContext();
            
            var firstUser = new User { Name = userName };
            var game = new Game { FirstUser = firstUser };

            context.Games.AddRange(game);
            await context.SaveChangesAsync();
            
            return game;
        }

        public async Task<Game?> GetGameAsync(int gameId)
        {
            using var context = new GamesContext();

            return await context.Games.
                 Include(g => g.FirstUser)
                .Include(g => g.SecondUser)
                .Include(g => g.Tournaments)
                .SingleOrDefaultAsync(g => g.Id == gameId);
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            using var context = new GamesContext();

            context.Games.Update(game);
            await context.SaveChangesAsync();

            return game;
        }
    }
}
