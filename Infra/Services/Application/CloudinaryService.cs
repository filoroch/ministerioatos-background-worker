using CloudinaryDotNet;

public class CloudinaryService : IStorageService
{   
    private readonly string _rootPath;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _client;
    private readonly Cloudinary _cloudinary;
    public CloudinaryService(IWebHostEnvironment env, HttpClient client, IConfiguration configuration)
    {
        _configuration = configuration;
        _client = client;
        _rootPath = env.ContentRootPath;

        var cloudnaryCloudName = _configuration["CLOUDINARY_CLOUDNAME"];
        var cloudnaryApiKey = _configuration["CLOUDINARY_APIKEY"];
        var cloudnaryApiSecret = _configuration["CLOUDINARY_APISECRET"];
        
        Account account = new Account(
            cloud: cloudnaryCloudName,
            apiKey: cloudnaryApiKey,
            apiSecret: cloudnaryApiSecret
        );

        _cloudinary = new Cloudinary(account);
    }

    public async Task DownloadResouceById(string id)
    {
        var url = await GetResourceById(id);
        var path = Path.Combine(_rootPath, "Resources");

        var response = await _client.GetAsync(
            url, 
            HttpCompletionOption.ResponseHeadersRead
        );

        response.EnsureSuccessStatusCode();
        
        var format = response.Content.Headers.ContentType?.MediaType;
        var extensao = ObterExtensaoPorContentType(format);

        var fileName = $"{id}{extensao}";
        var filePath = Path.Combine(path, fileName);

        using var stream = await response.Content.ReadAsStreamAsync();
        using var store = new FileStream(
            filePath, 
            FileMode.Create, 
            FileAccess.Write,
            FileShare.Read
        );

        await stream.CopyToAsync(store);
    }

    private string ObterExtensaoPorContentType(string? contentType)
    {
        return contentType switch
        {
            "application/pdf" => ".pdf",
            "image/jpeg" => ".jpg",
            "image/png" => ".png",
            "text/csv" => ".csv",
            "application/json" => ".json",
            "application/zip" => ".zip",
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" => ".xlsx",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document" => ".docx",
            _ => "" // Retorna vazio se não reconhecer, mantendo apenas o ID
        };
    }

    public Task<string> GetResourceByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetResourceById(string id)
    {
        var response = await _cloudinary.GetResourceAsync(id);
        return response.Url;
    }
}