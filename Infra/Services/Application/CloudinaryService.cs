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

        var cloudnaryCloudName = _configuration["CLOUDNARY_CLOUDNAME"];
        var cloudnaryApiKey = _configuration["CLOUDNARY_APIKEY"];
        var cloudnaryApiSecret = _configuration["CLOUDNARY_APISECRET"];
        
        Account account = new Account(
            cloud: cloudnaryCloudName,
            apiKey: cloudnaryApiKey,
            apiSecret: cloudnaryApiSecret
        );

        _cloudinary = new Cloudinary(account);
    }

    public async Task DownloadResouceById(string id)
    {
        var url = this.GetResourceById(id);
        var path = $"{_rootPath}/Resources";

        var response = await _client.GetAsync(
            url.Result, 
            HttpCompletionOption.ResponseHeadersRead
        );

        response.EnsureSuccessStatusCode();
        
        var stream = await response.Content.ReadAsStreamAsync();
        var store = new FileStream(
            path, 
            FileMode.Create, 
            FileAccess.Write,
            FileShare.Read
        );

        await stream.CopyToAsync(store);
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