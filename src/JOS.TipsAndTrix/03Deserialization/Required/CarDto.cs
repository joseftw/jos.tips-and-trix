using System.Collections.Generic;

namespace JOS.TipsAndTrix._03Deserialization.Required;

public class CarDto
{
    public required string Brand { get; init; }
    public required string Model { get; init; }
    public required uint Horsepower { get; init; }
    public required List<CustomPartDto> CustomParts { get; init; }
}
