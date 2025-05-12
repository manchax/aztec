using AztecDateTranslator.Shared.Entities;
using AztecDateTranslator.Shared.Model;

/// <summary>
/// 
/// </summary>
public interface IDateTranslator
{
    /// <summary>
    /// Gets the Tonalpohualli (aztec) - Tzolkin (maya) date
    /// which correlates to the given
    /// Gregorian <paramref name="date"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="AztecDateTranslator.Shared.Model.Tonalpohualli"/>
    /// </returns>
    Tonalpohualli Tonalpohualli(DateTime gregorian);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gregorian"></param>
    /// <returns>
    /// </returns>
    (Cempohuallapohualli mes, int dia) Xiuhpohualli(DateTime gregorian);
}