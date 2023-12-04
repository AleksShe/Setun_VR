using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
public class JsonConverter<T>
{
    private string _jsonData;
    public JsonConverter(JArray jsonData) => _jsonData = jsonData.ToString();
    public JsonConverter(JObject jsonData) => _jsonData = jsonData.ToString();
    public List<T> JsonArray => JsonConvert.DeserializeObject<List<T>>(_jsonData);
    public T JsonObject => JsonConvert.DeserializeObject<T>(_jsonData);
}
