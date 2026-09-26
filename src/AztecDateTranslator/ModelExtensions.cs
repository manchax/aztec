using AztecDateTranslator.Shared.Model;

namespace AztecDateTranslator;

public static class ModelExtensions
{
    extension(DaySign sign)
    {
        /// <summary>
        /// Gets the filename that belongs to the day sign
        /// represented by <paramref name="sign"/>.
        /// </summary>
        /// <returns>PNG file name.</returns>
        public string Image => $"d{sign.DayNumber}.png";
    }
}
