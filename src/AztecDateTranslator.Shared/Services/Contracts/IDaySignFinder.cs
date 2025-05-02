using AztecDateTranslator.Shared.Entities;

/// <summary>
/// Defines the contract to find a Tzolkin position
/// from a Gregorian date.
/// </summary>
public interface IDaySignTranslator
{
    /// <summary>
    /// Gets the <see cref="DaySign"/> which corresponds
    /// to the given <paramref name="date"/>.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    DaySign GetMoonDate(DateTime date);
}