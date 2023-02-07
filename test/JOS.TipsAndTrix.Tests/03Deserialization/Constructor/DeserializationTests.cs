using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using JOS.TipsAndTrix._03Deserialization.Constructor;
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace JOS.TipsAndTrix.Tests._03Deserialization.Constructor;

public class DeserializationTests
{
    private readonly EmbeddedResourceQuery _embeddedResourceQuery;

    public DeserializationTests()
    {
        _embeddedResourceQuery = new EmbeddedResourceQuery();
    }
    
    [Fact]
    public async Task CanDeserializeValidCarsJson()
    {
        await using var json = _embeddedResourceQuery.Read<EmbeddedResourceQuery>("_03Deserialization.Cars.json");
        if (json is null)
        {
            throw new Exception("Failed to read JSON from _03Deserialization.Cars.json");
        }

        var result = await JsonSerializer.DeserializeAsync<List<CarDto>>(json, CarsJsonSerializerOptions.Options);

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
    public async Task ShouldThrowIfRequiredPropertyIsNotSet()
    {
        await using var json =
            _embeddedResourceQuery.Read<EmbeddedResourceQuery>("_03Deserialization.CarsWithoutRequiredProperties.json");

        var exception = await
            Should.ThrowAsync<ArgumentNullException>(
                async () => await JsonSerializer.DeserializeAsync<List<CarDto>>(json!, CarsJsonSerializerOptions.Options));

        exception.Message.ShouldBe("Value cannot be null. (Parameter 'customParts')");
    }
}