/// <summary>
/// Implementação do contrato do Youtube aplicado a API
/// </summary>
public class YoutubeAPIService : IYoutube
{
    private IConfiguration _configuration;
    private readonly ILogger<YoutubeAPIService> Logger;
    private HttpClient Client;

    public YoutubeAPIService
    (
        IConfiguration configuration,
        HttpClient client, 
        ILogger<YoutubeAPIService> logger
    )
    {
        _configuration = configuration;
        Client = client;
        Logger = logger;
    }

    public Task<List<T>> GetLivestreamsAsync<T>()
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetCompletedLivestreamsAsync<T>()
    {
        // Pega as configurações DENTRO do método, usando o IConfiguration
        string baseEndpoint = _configuration["YOUTUBE_ENDPOINT"] ?? "https://www.googleapis.com/youtube/v3";
        string apiKey = _configuration["YOUTUBE_APIKEY"];
        string channelId = _configuration["YOUTUBE_CHANNELID"];
        string playlistId = "UU8em8RVeK5LuVnvGgfeqmNw";
        string completeUrl = $"{baseEndpoint}/playlistItems?part=snippet&playlistId={playlistId}&maxResults=5&key={apiKey}";

        //string completeUrl = $"https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=UC8em8RVeK5LuVnvGgfeqmNw&type=video&eventType=completed&key=AIzaSyAZ3MS9Sjq8UCmcZsbyR52mOTZpb8XjXEE";

        // Faz a requisição ao Youtube
        try 
        {
            HttpResponseMessage response = await Client.GetAsync(completeUrl);
            
            if(response.IsSuccessStatusCode != true)
            {
                string error = await response.Content.ReadAsStringAsync();
                Logger.LogError($"Falha no serviço do youtube. Detalhes: {error}");
                throw new Exception("Ocorreu um erro ao fazer a requisição");
            }

            var result = await response.Content.ReadFromJsonAsync<YoutubeRootResponse<T>>();
            return result?.Items ?? new List<T>();
        }
        catch(Exception ex)
        {
            Logger.LogError($"Ocorreu um erro ao recuperar as lives do youtube. {ex.Message}");
            throw;
        }
    }
}