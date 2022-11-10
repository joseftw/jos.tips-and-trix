using System;
using System.Collections.Generic;

namespace JOS.TipsAndTrix._03Deserialization.Constructor;

public class CarDto
{
    public CarDto(string brand, string model, List<CustomPartDto> customParts, uint horsepower)
    {
        Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        Model = model ?? throw new ArgumentNullException(nameof(model));
        CustomParts = customParts ?? throw new ArgumentNullException(nameof(customParts));
        Horsepower = horsepower;
    }

    public string Brand { get; }
    public string Model { get; }
    public uint Horsepower { get; }
    public List<CustomPartDto> CustomParts { get; }
}