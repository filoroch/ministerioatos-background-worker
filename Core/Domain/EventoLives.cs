public class EventoLives
{
    public int Id {get; set;}
    public Evento Evento {get; set;}
    /// <summary>
    /// Representa a url da live que foi agendada no youtube
    /// </summary>
    public string UrlLive {get; set;}
    /// <summary>
    /// Representa a url da thumb que foi agendada no youtube
    /// </summary>
    public string UrlThumb {get; set;}

    public EStatusEventoLive Status {get; set;}
}

