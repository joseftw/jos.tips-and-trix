using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using JOS.TipsAndTrix._03Deserialization.Yolo;
using Shouldly;
using Xunit;

namespace JOS.TipsAndTrix.Tests._03Deserialization.Yolo;

public class DeserializationTests
{
    [Fact]
    public void CanDeserializeValidCarsJson()
    {
        var result = JsonSerializer.Deserialize<List<CarDto>>(CarsJson.Valid, CarsJsonSerializerOptions.Options);

        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        result[0].Brand.ShouldBe("Ferrari");
        result[0].Model.ShouldBe("Enzo");
        result[0].Horsepower.ShouldBe(651u);
        result[0].CustomParts.Count.ShouldBe(1);
        result[0].CustomParts[0].PartNumber.ShouldBe("ABC123");
        result[0].CustomParts[0].Price.ShouldBe(1999.99M);
        result[0].CustomParts[0].Manufactured.ShouldBe(DateOnly.Parse("2021-01-12"));

        result[1].Brand.ShouldBe("Ferrari");
        result[1].Model.ShouldBe("F50");
        result[1].Horsepower.ShouldBe(512u);
        result[1].CustomParts.Count.ShouldBe(1);
        result[1].CustomParts[0].PartNumber.ShouldBe("DEF123");
        result[1].CustomParts[0].Price.ShouldBe(3050.99M);
        result[1].CustomParts[0].Manufactured.ShouldBe(DateOnly.Parse("2021-02-03"));

        result[2].Brand.ShouldBe("Ferrari");
        result[2].Model.ShouldBe("488 Spider");
        result[2].Horsepower.ShouldBe(661u);
        result[2].CustomParts.Count.ShouldBe(1);
        result[2].CustomParts[0].PartNumber.ShouldBe("GHI123");
        result[2].CustomParts[0].Price.ShouldBe(999.99M);
        result[2].CustomParts[0].Manufactured.ShouldBe(DateOnly.Parse("2021-07-10"));
    }

    [Fact]
    public void ShouldThrowArgumentNullExceptionWhenTryingToConsumeCustomPartsWhenCustomPartsIsMissingFromJson()
    {
        var result = JsonSerializer.Deserialize<List<CarDto>>(
            CarsJson.WithoutRequiredProperties, CarsJsonSerializerOptions.Options);

        var exception = Should.Throw<ArgumentNullException>(() => result!.First().CustomParts.First());
        exception.Message.ShouldBe("Value cannot be null. (Parameter 'source')");
    }
}
