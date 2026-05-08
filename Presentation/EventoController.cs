using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventoService service;

    public EventoController(IEventoService _eventoService)
    {
        service = _eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEventoAsync()
    {
        var events = await service.GetEventosAsync();
        return Ok(events);
    }

    [HttpPost]
    public async Task<IActionResult> PostEventoAsync([FromBody] CreateEventoCommander createEventoCommander)
    {
        var id = await service.Create(createEventoCommander);
        var uri = new Uri($"/api/Evento/{id}", UriKind.Relative);
        return CreatedAtAction("GetEventoById", new { id = id }, id);
    }
}