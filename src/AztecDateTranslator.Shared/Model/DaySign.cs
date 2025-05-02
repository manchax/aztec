namespace AztecDateTranslator.Shared.Entities;

/// <summary>
/// Represents one of the 20 aztec day signs.
/// </summary>
public class DaySign : BaseEntity
{
    public Naguales Nagual { get; set; }

    public byte DayNumber { get; set; }

    public string NahuatlName { get; set; }
        = string.Empty;

    public string SpanishName { get; set; }
        = string.Empty;

    public string EnglishName { get; set; }
        = string.Empty;

    /// <summary>
    /// Náhuatl name of Aztec deity associated to this day.
    /// </summary>
    public string AztecDeity { get; set; }
        = string.Empty;
}