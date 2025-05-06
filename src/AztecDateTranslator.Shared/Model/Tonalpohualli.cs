using AztecDateTranslator.Shared.Entities;
namespace AztecDateTranslator.Shared.Model;
/*
Moon Calendar System

This was a type of Aztec calendar dedicated to dates considered mystical and organized around a 260-day year,
with 20 months of 13 days each.

This calendar functioned as a record of auspicious dates for important events, such as the best days for sowing, 
harvesting, or making expeditionary journeys.

In the Tonalpohualli, each of the 260 days of the year have a name created from a system 
that combines the names of the 20 days of the solar calendar with a numbering system between 1 and 13. 

This system avoided the repetition of names.

Thus, the first week of the civil calendar began on 
1 Cipactli (1-alligator) and ended on 13 Acatl (13-reed). 

The second week started at 1 Ocelotl (1- Jaguar) and the third at 1 Mázatl (1- deer).
*/

/// <summary>
/// Moon based calendar.
/// </summary>
public class Tonalpohualli
{
    /// <summary>
    /// 1-13
    /// </summary>
    public byte HeavenNumber { get; set; }

    /// <summary>
    /// 20 glyphs
    /// </summary>
    public DaySign? DaySign { get; set; }

    /// <summary>
    /// The position within the cycle (1-260)
    /// </summary>
    public int TzolkinPosition { get; set; }

    /// <summary>
    /// Special days are considered more energetic.
    /// </summary>
    public bool IsSpecial { get; set; }
}
