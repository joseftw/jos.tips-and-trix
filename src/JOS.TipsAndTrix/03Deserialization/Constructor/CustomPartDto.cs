using System;

namespace JOS.TipsAndTrix._03Deserialization.Constructor;

public class CustomPartDto
{
    public CustomPartDto(string partNumber, decimal price, DateOnly manufactured)
    {
        PartNumber = partNumber ?? throw new ArgumentNullException(nameof(partNumber));
        Price = price;
        Manufactured = manufactured;
    }

    public string PartNumber { get; }
    public decimal Price { get; }
    public DateOnly Manufactured { get; }
}