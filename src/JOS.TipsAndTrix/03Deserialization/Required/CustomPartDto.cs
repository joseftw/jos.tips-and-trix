using System;

namespace JOS.TipsAndTrix._03Deserialization.Required;

public class CustomPartDto
{
    public required string PartNumber { get; init; }
    public required decimal Price { get; init; }
    public required DateOnly Manufactured { get; init; }
}