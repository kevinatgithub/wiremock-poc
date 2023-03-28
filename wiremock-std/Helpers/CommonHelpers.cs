using System.Text.Json;

namespace wiremock_std.Helpers; 
public class CommonHelpers { 

    public static StringContent ToStringContent<T>(T obj)
    {
        var jsonContent = JsonSerializer.Serialize(obj);
        var stringContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        return stringContent;
    }

    public static T ToObject<T>(string objStr) => JsonSerializer.Deserialize<T>(objStr);
}
