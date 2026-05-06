public class EventoLives
{
    public int Id {get; set;}
    public Evento Evento {get; set;}
    public String Titulo {get; set;}
    public DateTime DataPublicacao {get; set;}
    public string UrlLive {get; set;}
    public string UrlThumb {get; set;}

    public EStatusEventoLive Status {get; set;}

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

