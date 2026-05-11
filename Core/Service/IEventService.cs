using MinisterioAtos.Application.Commanders.Evento;

public interface IEventoService
{
    Task<OutputEventoCommander> Create(InputEventoCommander cmd);
    Task<OutputEventoCommander> Update(InputEventoCommander cmd);
    Task<ICollection<OutputEventoCommander>> GetByDateRange(DateTime startDate, DateTime endDate);
    Task<ICollection<OutputEventoCommander>> GetEventosAsync();
    Task<ICollection<OutputEventoCommander>> GetByCongregacaoAsync();
    Task<ICollection<OutputEventoCommander>> GetEventsByStatusAsync();
}