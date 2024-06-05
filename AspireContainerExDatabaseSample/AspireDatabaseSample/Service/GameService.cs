using AspireDatabaseSample.Service.Models;

namespace AspireDatabaseSample.Service.Service;

public class GameService: IGameService
{
    private readonly AppDbContext _dbContext;

    public GameService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    async Task<Game> IGameService.Create(Game game)
    {
        if (game is not null)
        {
            game.Id = Guid.NewGuid().ToString();
            await _dbContext.Game.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }

        return game;
    }

    Game IGameService.Read(string id)
    {
        return _dbContext.Game.FirstOrDefault(m => m.Id == id);
    }

    IEnumerable<Game> IGameService.Read()
    {
        return _dbContext.Game.OrderByDescending(m => m.ReleaseDate).ToList();
    }
}