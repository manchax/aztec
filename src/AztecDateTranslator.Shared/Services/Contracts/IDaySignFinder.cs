using AztecDateTranslator.Shared.Entities;

/// <summary>
/// Defines the contract to find a Tzolkin position
/// from a Gregorian date.
/// </summary>
public interface IDaySignTranslator
{
    DaySign GetMoonDate(DateTime date);
}