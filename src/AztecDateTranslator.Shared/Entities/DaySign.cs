namespace AztecDateTranslator.Shared.Entities;

public class DaySign : BaseEntity
{
    public int Number { get; set; }

    public string NahuatlName { get; set; }
        = string.Empty;

    public string SpanishName { get; set; }

    public string EnglishName { get; set; }

    public Naguales Nagual { get; set; }
}