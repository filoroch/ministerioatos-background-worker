public class EventoLives
{
    public int Id {get; set;}
    public Evento Evento {get; set;}
    public String Titulo {get; set;}
    public DateTime DataPublicacao {get; set;}
    public string UrlLive {get; set;}
    public string UrlThumb {get; set;}

    public EStatusEventoLive Status {get; set;}

    public EventoLives(){}

    public EventoLives(Evento _evento, String _urlLive)
    {
        Evento = _evento;
        DefineTitulo();
        DefineDataHora();
        Status = EStatusEventoLive.Pendente;
        UrlLive = _urlLive;
        UrlThumb = "";
    }

    public void DefineUrl()
    {
        if (string.IsNullOrWhiteSpace(UrlLive))
        {
            throw new Exception("A url da Live não pode ser nula ou esta em branco");
        }
    }

    public void DefineTitulo()
    {
        var dia = Evento.DataHora.Day.ToString();
        var mes = Evento.DataHora.Month.ToString(); 
        var titulo = Evento.Titulo;

        Titulo = $"{dia}/{mes} | {titulo}";
    }

    public void DefineDataHora()
    {
        DataPublicacao = Evento.DataHora;
    }
}

