using Microsoft.Extensions.Logging;
using System.ComponentModel;
using AztecDateTranslator.Shared.Services;

namespace AztecDateTranslator.ViewModels;

// Use alias to avoid name conflict
using BaseTranslator = Shared.ViewModels.DateTranslator;

/// <summary>
/// Extends ViewModel with new property that's only available from
/// current assembly.
/// </summary>
/// <param name="dateTranslator"></param>
/// <param name="logger"></param>
public class DateTranslator(IDateTranslator dateTranslator,
    ILogger<DateTranslator> logger)
    : BaseTranslator(dateTranslator, logger)
{
    /// <summary>
    /// Image for the Tonalpohualli day sign.
    /// </summary>
    /// <remarks>
    /// Image files are provided by current assembly under
    /// <see href="Resources/Images/days"/>.
    /// </remarks>
    public string DaySignImage => Tonalpohualli?.DaySign?.Image ?? "";

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Tonalpohualli))
        {
            // update the image
            OnPropertyChanged(nameof(DaySignImage));
        }
        base.OnPropertyChanged(e);
    }
}
