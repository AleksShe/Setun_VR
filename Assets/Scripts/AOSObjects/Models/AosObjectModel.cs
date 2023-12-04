using Newtonsoft.Json;

public class AosObjectModel
{
    [JsonProperty("apiId")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
}
