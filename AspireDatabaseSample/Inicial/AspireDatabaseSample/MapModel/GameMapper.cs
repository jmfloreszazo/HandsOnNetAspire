using AspireDatabaseSample.Service.DTO;
using AspireDatabaseSample.Service.Models;
using AutoMapper;

namespace AspireDatabaseSample.Service.MapModel;

public class GameMapper : Profile
{
    public GameMapper()
    {
        // == > Source => Target
        // CreateMap<Source, Target>

        // Use inside request 
        CreateMap<Game, GameDTO>();

        // Use inside response
        CreateMap<GameDTO, Game>();
    }
}