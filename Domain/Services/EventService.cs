using Supabase;

public class EventService
{
    private readonly Client _supabase;
    public EventService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<Event>> GetEventsAsync()
    {
        var response = await _supabase.From<Event>().Get();
        return response.Models;
    }
}