using AztecDateTranslator.Shared.Model;
using AztecDateTranslator.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace AztecDateTranslator.Shared.ViewModels;

/// <summary>
/// MainPage ViewModel.
/// </summary>
public partial class DateTranslator : BaseViewModel
{
    private readonly IDateTranslator _dateTranslatorSvc;

    [ObservableProperty]
    private Tonalpohualli? _tonalpohualli;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TonalpohualliLabel))]
    private DateTime _selectedDate = DateTime.Now.Date;

    public DateTranslator(IDateTranslator dateTranslatorSvc,
        ILogger<DateTranslator> logger) : base(logger)
    {
        _dateTranslatorSvc = dateTranslatorSvc;
        _tonalpohualli = _dateTranslatorSvc.Tonalpohualli(_selectedDate);
        Previous = new AsyncRelayCommand(() => Task.Run(() =>
        {
            SelectedDate = SelectedDate.AddDays(-1);
        }));
        Next = new AsyncRelayCommand(() => Task.Run(() =>
        {
            SelectedDate = SelectedDate.AddDays(1);
        }));
        Current = new AsyncRelayCommand(() => Task.Run(() =>
        {
            SelectedDate = DateTime.Now.Date;
        }));
    }

    public IAsyncRelayCommand Previous { get; }

    public IAsyncRelayCommand Current { get; } = new AsyncRelayCommand(
        () => Task.CompletedTask);

    public IAsyncRelayCommand Next { get; }

    public string TonalpohualliLabel
        => $"Tonalpohualli: {Tonalpohualli?.HeavenNumber} {Tonalpohualli?.DaySign?.Nahuatl}";

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedDate))
        {
            Tonalpohualli = _dateTranslatorSvc.Tonalpohualli(SelectedDate);
            Logger.LogInformation("OnPropertyChanged: {PropertyName} = {SelectedDate}",
                e.PropertyName, SelectedDate.ToShortDateString());
        }
        base.OnPropertyChanged(e);
    }
}
