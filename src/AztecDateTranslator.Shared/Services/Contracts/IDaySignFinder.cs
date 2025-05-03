using AztecDateTranslator.Shared.Entities;
using AztecDateTranslator.Shared.Model;

/// <summary>
/// 
/// </summary>
public interface IDaySignTranslator
{
    /// <summary>
    /// Gets the <see cref="DaySign"/> which corresponds
    /// to the given <paramref name="date"/>.
    /// </summary>
    /// <returns>Tzolkin day.</returns>
    Tonalpohualli GetTzolkinDate(DateTime date);
}