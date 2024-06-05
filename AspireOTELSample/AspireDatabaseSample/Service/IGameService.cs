using AspireDatabaseSample.Service.Models;

namespace AspireDatabaseSample.Service.Service;

public interface IGameService
{
    Task<Game> Create(Game game);
    IEnumerable<Game> Read();
    Game Read(string id);
}