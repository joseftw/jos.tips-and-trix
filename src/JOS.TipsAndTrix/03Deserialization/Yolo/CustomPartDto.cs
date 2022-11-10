#pragma warning disable CS8618

using System;

namespace JOS.TipsAndTrix._03Deserialization.Yolo;

public class CustomPartDto
{
    public string PartNumber { get; set; }
    public decimal Price { get; set; }
    public DateOnly Manufactured { get; set; }
}