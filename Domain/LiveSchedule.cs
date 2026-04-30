using System.ComponentModel.DataAnnotations.Schema;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using ColumnAttribute = Supabase.Postgrest.Attributes.ColumnAttribute;

public class LiveSchedule : BaseModel
{
    [PrimaryKey("id")]
    public int Id {get; set;}

    [ForeignKey("event_id")]
    public int EventId {get; set;}

    [Column("date_time")]
    public DateTime DateTime {get; set;}

    [Column("title")]
    public string Title {get; set;}

    [Column("status")]
    public string Status {get; set;}

    public LiveSchedule
    (
        int eventId,
        DateTime dateTime,
        string Title
    )
    {
        EventId = eventId;
        DateTime = dateTime;
        Status = "PENDENTE";
    }

    public void DefineTitle(DateTime dateTimeOnEvent, string titleEvent)
    {
        if(string.IsNullOrEmpty(titleEvent))
        {
            throw new Exception("Titulo não pode ser nulo ou vazio");
        }
        
        Title = $"{dateTimeOnEvent.Day.ToString()}/{dateTimeOnEvent.Month.ToString()} | {titleEvent}"; 
    }
}