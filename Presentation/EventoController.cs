using Microsoft.AspNetCore.Mvc;
using MinisterioAtos.Application.Commanders.Evento;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventoService service;

    public EventoController(IEventoService _eventoService)
    {
        service = _eventoService;
    }

    // TODO: Garantir que o retorno aqui seja um json com objetos e não uma lista de jsons
    [HttpGet]
    public async Task<IActionResult> GetEventoAsync([FromQuery] FilterEventoCommander filter)
    {
        ICollection<OutputEventoCommander>? events = null;

        if (filter == null)
        {
            events = await service.GetEventosAsync();
        }

        return Ok(events);
    }

    [HttpPost]
    public async Task<IActionResult> PostEventoAsync([FromBody] InputEventoCommander createEventoCommander)
    {
        var created = await service.Create(createEventoCommander);
        return Accepted(nameof(PostEventoAsync), created);
    }
}