using AspireDatabaseSample.Service.DTO;
using AspireDatabaseSample.Service.Models;
using AspireDatabaseSample.Service.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspireDatabaseSample.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IMapper _mapper;

    public GameController(IGameService gameService, IMapper mapper)
    {
        _gameService = gameService;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var model = _gameService.Read();
        if (model.Any()) return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<GameDTO>>(model));
        return StatusCode(StatusCodes.Status204NoContent);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(string id)
    {
        var model = _gameService.Read(id);
        if (model is not null) return StatusCode(StatusCodes.Status200OK, _mapper.Map<GameDTO>(model));
        return StatusCode(StatusCodes.Status404NotFound);
    }

    [HttpPost]
    public async Task<IActionResult> Post(GameDTO gameDto)
    {
        var mapModel = _mapper.Map<Game>(gameDto);
        var result = await _gameService.Create(mapModel);
        if (result is not null) return StatusCode(StatusCodes.Status201Created, _mapper.Map<GameDTO>(result));
        return StatusCode(StatusCodes.Status400BadRequest);
    }
}