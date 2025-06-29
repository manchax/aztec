using System.ComponentModel.DataAnnotations;

namespace AztecDateTranslator.Shared.Model;

/// <summary>
/// Represents one of the 20 aztec day signs.
/// </summary>
public class DaySign : BaseEntity
{
    [Key]
    public int ID { get; set; }

    /// <summary>
    /// There are 20 days used in both calendars.
    /// </summary>
    public byte DayNumber { get; set; }

    /// <summary>
    /// The element associated to this day.
    /// </summary>
    public Naguales Nagual { get; set; }

    public string Nahuatl { get; set; }
        = string.Empty;

    public string Maya { get; set; }
        = string.Empty;

    public string Spanish { get; set; }
        = string.Empty;

    public string English { get; set; }
        = string.Empty;

    /// <summary>
    /// Náhuatl name of Aztec deity associated to this day.
    /// </summary>
    public string AztecDeity { get; set; }
        = string.Empty;

    public string Description { get; set; }
        = string.Empty;
}