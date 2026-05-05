using Supabase;

/// <summary>
/// Serviço que permite recuperar e registrar agendamentos de live a partir do banco de dados
/// </summary>
public class LiveScheduleService
{
    private readonly Client _supabase;

    public LiveScheduleService
    (
        Client supabase
    )
    {
        _supabase = supabase;
    }

    //async Task<List<LiveSchedule> GetScheduleFromId(int Id);
    //async Task<List<LiveSchedule> UpdateThumbnailOnScheduleById(int Id);

    /// <summary>
    /// Recupera a lista de todos os agendamentos do banco
    /// </summary>
    /// <returns></returns>
    public async Task<List<EventoLives>> GetSchedulesAsync()
    {
        throw new Exception("Teste");
    }

    // public Task<List<LiveSchedule>> GenerateSchedules(List<Event> eventsNotScheduled)
    // {
    //     List<LiveSchedule> scheduledEvents = new List<LiveSchedule>();
    //     eventsNotScheduled.ForEach(e => scheduledEvents.Add(new LiveSchedule(eventId: e.Id ,Title: e.Title, dateTime: e.Start))); 
    //     return scheduledEvents;
    // }
}