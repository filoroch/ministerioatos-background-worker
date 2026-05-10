public interface IStorageService
{
    Task<string> GetResourceById(string id);
    Task<string> GetResourceByName(string name);
    Task DownloadResouceById(string id);
}