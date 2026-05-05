using System.Text.Json.Serialization;

public class YoutubeSnippet
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("publishedAt")]
    public DateTime publishedAt {get; set;}
}