using Microsoft.Extensions.Logging;
using System.ComponentModel;
using AztecDateTranslator.Shared.Services;
using BaseTranslator = AztecDateTranslator.Shared.ViewModels.DateTranslator;

namespace AztecDateTranslator.ViewModels;

public class DateTranslator(IDateTranslator dateTranslator,
    ILogger<DateTranslator> logger)
    : BaseTranslator(dateTranslator, logger)
{
    public string ImageSource => Tonalpohualli?.DaySign?.GetImage() ?? "";

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Tonalpohualli))
        {
            OnPropertyChanged(nameof(ImageSource));
        }
        base.OnPropertyChanged(e);
    }
}
