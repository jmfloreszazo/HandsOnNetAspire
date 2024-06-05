using AspireDatabaseSample.Service.Models;

namespace AspireDatabaseSample.Service.Service;

public class GameService: IGameService
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<GameService> _logger; 

    public GameService(AppDbContext dbContext, ILogger<GameService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    async Task<Game> IGameService.Create(Game game)
    {
        _logger.LogInformation("Creating game");
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
        _logger.LogInformation("Reading game by Id");
        return _dbContext.Game.FirstOrDefault(m => m.Id == id);
    }

    IEnumerable<Game> IGameService.Read()
    {
        _logger.LogInformation("Reading all games");
        return _dbContext.Game.OrderByDescending(m => m.ReleaseDate).ToList();
    }
}