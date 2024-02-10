namespace Jewelry.Models.Enumerations;

using System.ComponentModel;

public enum Availability
{
    [Description("В наличност")]
    HighAvailability,
    [Description("Последни бройки")]
    LowAvailability,
    [Description("Изчерпан")]
    OutOfStock
}
