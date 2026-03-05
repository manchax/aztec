namespace AztecDateTranslator.Shared.Model;

/// <summary>
/// Represents a day in the Aztec calendar, including its numeric value, name, associated Mayan equivalent, description,
/// and deity.
/// </summary>
/// <remarks>This class is typically used to model and transfer information about individual days within the
/// Cempohuallapohualli, the Aztec 260-day ritual calendar. All properties are read-write to support serialization and
/// data binding scenarios.</remarks>
public class Cempohuallapohualli
{
    public int ID { get; set; }

    public int Number { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Maya { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Deity { get; set; } = string.Empty;
}
