using AztecDateTranslator.Shared.Services;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Diagnostics;

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
    private readonly SpeechOptions _ttsOptions = new();
    private CancellationTokenSource? _silence = new();

    /// <summary>
    /// Image for the Tonalpohualli day sign.
    /// </summary>
    /// <remarks>
    /// Image files are provided by current assembly under
    /// <see href="Resources/Images/days"/>.
    /// </remarks>
    public string DaySignImage => Tonalpohualli?.DaySign?.Image ?? "";

    protected override async void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        bool speak = false;
        if (e.PropertyName == nameof(Tonalpohualli))
        {
            // update the image
            OnPropertyChanged(nameof(DaySignImage));
            speak = true;
        }
        base.OnPropertyChanged(e);

        if (speak)
        {
            await DescribeDayAloud();
        }
    }

    public async Task DescribeDayAloud()
    {
        Silence();
        var daySign = Tonalpohualli?.DaySign
            ?? throw new NullReferenceException();

        await Speak(Tonalpohualli?.HeavenNumber + " "
            + daySign.Spanish);

        await Speak(Tonalpohualli?.HeavenNumber + " " +
            daySign.Nahuatl);

        await Speak(Tonalpohualli?.HeavenNumber + " " +
            daySign.Maya);

        await Speak("Dios Azteca: " +
            daySign.AztecDeity + ". " +
            daySign.Description);

        if (Tonalpohualli!.IsSpecial)
        {
            await Speak("Éste es considerado como un día especial.");
        }

        await Speak(SelectedDate.ToLongDateString());
    }

    private async Task Speak(string text)
    {
        _silence ??= new();
        try
        {
            await TextToSpeech.Default.SpeakAsync(text, _ttsOptions,
                cancelToken: _silence.Token);
        }
        catch (TaskCanceledException)
        {
            Debug.WriteLine("Task canceled.");
        }
    }

    private void Silence()
    {
        // _logger.LogInformation("Silencing...");
        _silence?.Cancel();
        _silence = new();
        // _logger.LogInformation("Silenced.");
    }
}
