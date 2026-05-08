using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EventoLiveController : ControllerBase
{
    private readonly IEventoLiveService _eventoLiveService;
    public EventoLiveController(IEventoLiveService eventoLiveService)
    {
        _eventoLiveService = eventoLiveService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEventByIdAsync([FromRoute] int id)
    {
        var result = await _eventoLiveService.GetEventoLiveByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetEventoAsync()
    {
        var eventsWithLive = await _eventoLiveService.GetEventsLiveAsync();
        return Ok(eventsWithLive);
    }
}