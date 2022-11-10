using System.Text.Json;

namespace JOS.TipsAndTrix.Tests._03Deserialization;

public class CarsJsonSerializerOptions
{
    static CarsJsonSerializerOptions()
    {
        Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
    public static JsonSerializerOptions Options { get; }
}