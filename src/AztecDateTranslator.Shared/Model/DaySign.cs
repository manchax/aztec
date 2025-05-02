using System.ComponentModel.DataAnnotations;

namespace AztecDateTranslator.Shared.Entities;

/// <summary>
/// Represents one of the 20 aztec day signs.
/// </summary>
public class DaySign : BaseEntity
{
    [Key]
    public int ID { get; set; }

    public byte DayNumber { get; set; }

    public Naguales Nagual { get; set; }

    public string Nahuatl { get; set; }
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
}