using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

/// <summary>
/// Representa os eventos da igreja
/// </summary>
[Table("event")]
public class Event : BaseModel
{
    [PrimaryKey("id")]
    public int Id {get; set; }

    [Column("title")]
    public string Title {get; set; }
    
    [Column("description")]
    public string Description {get; set; }

    [Column("start")]
    public DateTime Start {get; set;}

    [Column("local")]
    public string Local {get; set;}

    [Column("created_at")]
    public string CreatedAt {get; set; }

    public override string ToString()
    {
        return $"{Id} {Title} {Start}";
    }
}