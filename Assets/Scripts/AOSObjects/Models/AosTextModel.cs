using Newtonsoft.Json;
public class AosTextModel 
{
    [JsonProperty("name")]
    public string Header { get; set; }
    [JsonProperty("text")]
    public string Text { get; set; }
}
