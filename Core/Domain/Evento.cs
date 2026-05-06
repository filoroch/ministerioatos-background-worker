/// <summary>
/// Representa os eventos da igreja
/// </summary>
public class Evento 
{
    public virtual int Id {get; set; }

    public virtual string Titulo {get; set; }
    
    public virtual string Descricao {get; set; }

    public virtual DateTime DataHora {get; set;}

    public virtual Congregacao Congregacao {get; set;}
    public virtual StatusEvento Status {get; set;}

    public override string ToString()
    {
        return $"{Id} | {Titulo} | {DataHora} | {Congregacao.Titulo} | {Status}";
    }
    
}

