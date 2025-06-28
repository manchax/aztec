using AztecDateTranslator.Shared.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace AztecDateTranslator.Shared.ViewModels;

/// <summary>
/// MainPage ViewModel.
/// </summary>
public partial class DateTranslator(
        IDateTranslator dateTranslatorSvc,
        ILogger<DateTranslator> logger)
    : BaseViewModel(logger)
{
    // private readonly ILogger<DateTranslator> _logger = logger;

    [ObservableProperty]
    private Tonalpohualli? _tonalpohualli;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TonalpohualliLabel))]
    private DateTime _selectedDate = DateTime.Now.Date;

    public string TonalpohualliLabel 
        => $"Tonalpohualli: {Tonalpohualli?.HeavenNumber} {Tonalpohualli?.DaySign?.Nahuatl}";

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedDate))
        {
            Tonalpohualli = dateTranslatorSvc.Tonalpohualli(SelectedDate);
            Logger.LogInformation("OnPropertyChanged: {PropertyName} = {SelectedDate}",
                e.PropertyName, SelectedDate.ToShortDateString());            
        }
        base.OnPropertyChanged(e);
    }
}
