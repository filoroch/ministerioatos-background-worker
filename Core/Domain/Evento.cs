/// <summary>
/// Representa os eventos da igreja
/// </summary>
public class Evento 
{
    public int Id {get; set; }

    public string Titulo {get; set; }
    
    public string Descricao {get; set; }

    public DateTime DataHora {get; set;}

    public Congregacao Congregacao {get; set;}
    public StatusEvento Status;

    // public override string ToString()
    // {
    //     return $"{Id} {Title} {Start}";
    // }

    // public override bool Equals(object? obj)
    // {
    //     return base.Equals(obj);
    // }

    
}

