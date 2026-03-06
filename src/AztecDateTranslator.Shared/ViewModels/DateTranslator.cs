using AztecDateTranslator.Shared.Model;
using AztecDateTranslator.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace AztecDateTranslator.Shared.ViewModels;

/// <summary>
/// Base ViewModel.
/// </summary>
public abstract partial class DateTranslator : BaseViewModel
{
    private readonly IDateTranslator _dateTranslatorSvc;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TonalpohualliLabel))]
    [NotifyPropertyChangedFor(nameof(IsSpecial))]
    [NotifyPropertyChangedFor(nameof(Deity))]
    [NotifyPropertyChangedFor(nameof(DeityDescription))]
    [NotifyPropertyChangedFor(nameof(DeityHorizontal))]
    [NotifyPropertyChangedFor(nameof(Position))]
    [NotifyPropertyChangedFor(nameof(DaySignSpanish))]
    private DateTime _selectedDate = DateTime.Now.Date;

    [ObservableProperty]
    private Tonalpohualli? _tonalpohualli;

    public DateTranslator(IDateTranslator dateTranslatorSvc,
        ILogger<DateTranslator> logger) : base(logger)
    {
        _dateTranslatorSvc = dateTranslatorSvc;
        _tonalpohualli = _dateTranslatorSvc.Tonalpohualli(_selectedDate);
        Previous = new AsyncRelayCommand(() => Task.Run(() =>
            SelectedDate = SelectedDate.AddDays(-1)
        ));
        Next = new AsyncRelayCommand(() => Task.Run(() =>
            SelectedDate = SelectedDate.AddDays(1)
        ));
        Current = new AsyncRelayCommand(() => Task.Run(() =>
            SelectedDate = DateTime.Now.Date
        ));
    }

    /// <summary>
    /// Text description of the Tonalpohualli date.
    /// </summary>
    public string TonalpohualliLabel =>
        $"Tonalpohualli: {Tonalpohualli?.HeavenNumber}" +
        $" {Tonalpohualli?.DaySign?.Nahuatl}" +
        $" ({Tonalpohualli?.DaySign?.Maya}) ";

    /// <summary>
    /// Special days are considered more energetic.
    /// </summary>
    public char IsSpecial => (Tonalpohualli?.IsSpecial ?? false) ? 'Y' : 'N';

    /// <summary>
    /// Aztec deity name.
    /// </summary>
    public string Deity => Tonalpohualli?.DaySign?.AztecDeity ?? "";

    public string DaySignSpanish => Tonalpohualli?.DaySign?.Spanish ?? "";

    /// <summary>
    /// Aztec deity description.
    /// </summary>
    public string DeityDescription => Tonalpohualli?.DaySign?.Description ?? "";

    /// <summary>
    /// Deity associated to the Tonalpohualli date in Nahuatl and Spanish.
    /// </summary>
    public string DeityHorizontal
        => $"{Tonalpohualli?.DaySign?.AztecDeity} - {Tonalpohualli?.DaySign?.Description}.";

    public int Position => Tonalpohualli?.DayNumber ?? default;

    /// <summary>
    /// Changes <see cref="SelectedDate"/> to the previous day.
    /// </summary>
    public IAsyncRelayCommand Previous { get; }

    /// <summary>
    /// Changes <see cref="SelectedDate"/> to current computer's date.
    /// See: <see cref="DateTime.Now"/>.
    /// </summary>
    public IAsyncRelayCommand Current { get; }

    /// <summary>
    /// Changes <see cref="SelectedDate"/> to the next day.
    /// </summary>
    public IAsyncRelayCommand Next { get; }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        // when SelectedDate changes, update Tonalpohualli
        if (e.PropertyName == nameof(SelectedDate))
        {
            /// use NEW date <see cref="_selectedDate"/>
            Tonalpohualli = _dateTranslatorSvc.Tonalpohualli(SelectedDate);
            Logger.LogInformation("OnPropertyChanged: {PropertyName} = {SelectedDate}",
                e.PropertyName, SelectedDate.ToShortDateString());
        }
        base.OnPropertyChanged(e);
    }
}
