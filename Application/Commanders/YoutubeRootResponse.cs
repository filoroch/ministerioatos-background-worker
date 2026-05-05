using System.Text.Json.Serialization;
using System.Collections.Generic;

public class YoutubeRootResponse<T>
{
    [JsonPropertyName("items")]
    public List<T> Items { get; set; } = new List<T>();
}