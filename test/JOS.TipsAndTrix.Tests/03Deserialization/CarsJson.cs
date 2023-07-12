namespace JOS.TipsAndTrix.Tests._03Deserialization;

public static class CarsJson
{
    public const string Valid = """
        [{
           "brand": "Ferrari",
           "model": "Enzo",
           "horsePower": 651,
           "customParts": [{
             "partNumber": "ABC123",
             "price": 1999.99,
             "manufactured": "2021-01-12"
           }]
        },
        {
          "brand": "Ferrari",
          "model": "F50",
          "horsePower": 512,
          "customParts": [{
            "partNumber": "DEF123",
            "price": 3050.99,
            "manufactured": "2021-02-03"
          }]
        },
        {
          "brand": "Ferrari",
          "model": "488 Spider",
          "horsePower": 661,
          "customParts": [{
            "partNumber": "GHI123",
            "price": 999.99,
            "manufactured": "2021-07-10"
          }]
        }]
        """;

    public const string WithoutRequiredProperties = """
        [
          {
            "brand": "Ferrari",
            "model": "Enzo",
            "horsePower": 651
          },
          {
            "brand": "Ferrari",
            "model": "F50",
            "horsePower": 512
          },
          {
            "brand": "Ferrari",
            "model": "488 Spider",
            "horsePower": 661
          }
        ]
        """;

    public const string WithNullProperties = """
        [
          {
            "brand": "Ferrari",
            "model": null,
            "horsePower": 651,
            "customParts": [{
              "partNumber": "ABC123",
              "price": 1999.99,
              "manufactured":"2021-01-12"
            }]
          },
          {
            "brand": "Ferrari",
            "model": null,
            "horsePower": 512,
            "customParts": [{
              "partNumber": "DEF123",
              "price": 3050.99,
              "manufactured":"2021-02-03"
            }]
          },
          {
            "brand": "Ferrari",
            "model": null,
            "horsePower": 661,
            "customParts": [{
              "partNumber": "GHI123",
              "price": 999.99,
              "manufactured": "2021-07-10"
            }]
          }]
        """;
}
