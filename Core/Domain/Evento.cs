/// <summary>
/// Representa os eventos da igreja
/// </summary>
public class Evento 
{
    public virtual int Id {get; set; }

    public virtual string Titulo {get; set; }
    
    public virtual string? Descricao {get; set; }

    public virtual DateTime DataHora {get; set;}

    public virtual Congregacao? Congregacao {get; set;}
    public virtual StatusEvento Status {get; set;}

    public Evento(){}
    public Evento
    (
        String _titulo, 
        DateTime _dataHora, 
        String? _descricao,
        Congregacao? _congregacao 
    )
    {
        Titulo = String.IsNullOrWhiteSpace(_titulo) ? throw new DomainException("Titulo não pode ser nulo ou estar em branco para registar um novo evento") : _titulo; 
        DataHora = _dataHora;
        Descricao = String.IsNullOrWhiteSpace(_descricao) ? _descricao : "";
        
        if (_congregacao != null)
        {
            Congregacao = _congregacao;
        }
    }
    public override string ToString()
    {
        return $"{Id} | {Titulo} | {DataHora} | {Congregacao.Titulo} | {Status}";
    }
    
}

