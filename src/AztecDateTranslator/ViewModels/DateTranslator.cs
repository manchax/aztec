using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace AztecDateTranslator.ViewModels;

public class DateTranslator(IDateTranslator dateTranslator,
    ILogger<Shared.ViewModels.DateTranslator> logger)
    : Shared.ViewModels.DateTranslator(dateTranslator, logger)
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
