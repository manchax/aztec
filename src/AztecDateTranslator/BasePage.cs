using AztecDateTranslator.Shared.ViewModels;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AztecDateTranslator;

public abstract class BasePage<TViewModel> : BasePage
    where TViewModel : BaseViewModel
{
    public BasePage(TViewModel viewModel) : base(viewModel)
    {
        Unloaded += (s, e) =>
        {
#if DEBUG
            var msg = $"OnUnLoaded: {Title}.";
            BindingContext?.Logger.LogInformation(msg);
#endif
        };
    }

    public new TViewModel BindingContext => (TViewModel)base.BindingContext;
}

public abstract class BasePage : ContentPage
{
    protected BasePage(object? viewModel = null)
    {
        BindingContext = viewModel;

        if (string.IsNullOrWhiteSpace(Title))
        {
            Title = GetType().Name;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Debug.WriteLine($"OnAppearing: {Title}");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        Debug.WriteLine($"OnDisappearing: {Title}");
    }
}