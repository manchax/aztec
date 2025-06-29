using AztecDateTranslator.Shared.Entities;

namespace AztecDateTranslator;

public static class ModelExtensions
{
    extension(DaySign sign)
    {
        public string GetImage() => $"d{sign.DayNumber}.png";
    }
}
