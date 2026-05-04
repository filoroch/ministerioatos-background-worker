public interface IEventService
{
    Task<List<Event>> GetEventsAsync();
}