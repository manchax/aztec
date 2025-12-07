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
    /// Used as binding property in
    /// line 31 in <see href="../MainPage.xaml" />
    /// </remarks>
    public string ImageSource => Tonalpohualli?.DaySign?.GetImage() ?? "";

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Tonalpohualli))
        {
            // update the image
            OnPropertyChanged(nameof(ImageSource));
        }
        base.OnPropertyChanged(e);
    }
}
