using AztecDateTranslator.Shared.Model;

public static class ModelExtensions
{
    extension(DaySign sign)
    {
        public string GetImage() => $"d{sign.DayNumber}.png";
    }
}
