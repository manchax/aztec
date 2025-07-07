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
    [NotifyPropertyChangedFor(nameof(TonalpohualliLabel))]
    [NotifyPropertyChangedFor(nameof(IsSpecial))]
    [NotifyPropertyChangedFor(nameof(AztecDeity))]
    [NotifyPropertyChangedFor(nameof(AztecDeityDescription))]
    [NotifyPropertyChangedFor(nameof(AztecDeityHorizontal))]
    private DateTime _selectedDate = DateTime.Now.Date;

    [ObservableProperty]
    private Tonalpohualli? _tonalpohualli;

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

    /// <summary>
    /// Text description of the Tonalpohualli date.
    /// </summary>
    public string TonalpohualliLabel
        => $"Tonalpohualli: {Tonalpohualli?.HeavenNumber} {Tonalpohualli?.DaySign?.Nahuatl}";

    /// <summary>
    /// Special days are considered more energetic.
    /// </summary>
    public char IsSpecial => (Tonalpohualli?.IsSpecial ?? false) ? 'Y' : 'N';

    /// <summary>
    /// Aztec deity name.
    /// </summary>
    public string AztecDeity => $"{Tonalpohualli?.DaySign?.AztecDeity}";

    /// <summary>
    /// Aztec deity description.
    /// </summary>
    public string AztecDeityDescription => $"{Tonalpohualli?.DaySign?.Description}";

    /// <summary>
    /// Deity associated to the Tonalpohualli date in Nahuatl and Spanish.
    /// </summary>
    public string AztecDeityHorizontal
        => $"{Tonalpohualli?.DaySign?.AztecDeity} - {Tonalpohualli?.DaySign?.Description}.";

    /// <summary>
    /// Changes <see cref="SelectedDate"/> to the previous day.
    /// </summary>
    public IAsyncRelayCommand Previous { get; }

    /// <summary>
    /// Changes <see cref="SelectedDate"/> to the current day.
    /// </summary>
    public IAsyncRelayCommand Current { get; }

    /// <summary>
    /// Changes <see cref="SelectedDate"/> to the next day.
    /// </summary>
    public IAsyncRelayCommand Next { get; }

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
