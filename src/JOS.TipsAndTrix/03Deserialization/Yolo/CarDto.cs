#pragma warning disable CS8618

using System.Collections.Generic;

namespace JOS.TipsAndTrix._03Deserialization.Yolo;

public class CarDto
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public uint Horsepower { get; set; }
    public List<CustomPartDto> CustomParts { get; set; }
}