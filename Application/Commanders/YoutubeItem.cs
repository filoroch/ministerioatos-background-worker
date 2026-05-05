// 2. O formato do item que queremos mapear
using System.Text.Json.Serialization;

public class YoutubeItem
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("snippet")]
    public YoutubeSnippet Snippet { get; set; }
}