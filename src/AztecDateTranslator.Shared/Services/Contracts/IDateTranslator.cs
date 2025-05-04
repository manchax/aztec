using AztecDateTranslator.Shared.Entities;
using AztecDateTranslator.Shared.Model;

/// <summary>
/// 
/// </summary>
public interface IDateTranslator
{
    /// <summary>
    /// Gets the <see cref="DaySign"/> which corresponds
    /// to the given <paramref name="date"/>.
    /// </summary>
    /// <returns>Tzolkin day.</returns>
    Tonalpohualli Tonalpohualli(DateTime date);

    (Cempohuallapohualli mes, int dia) Xiuhpohualli(DateTime date);
}