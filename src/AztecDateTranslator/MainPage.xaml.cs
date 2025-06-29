using AztecDateTranslator.Shared.Services;
using DateTranslatorVM = AztecDateTranslator.ViewModels.DateTranslator;
using Microsoft.Extensions.Logging;

namespace AztecDateTranslator
{
    public partial class MainPage
    {
        public MainPage()
        {
            var app = (AztecDateTranslator.App)App.Current!;
            var logger = app!.Handler.GetService<ILogger<DateTranslatorVM>>();
            var translator = app.Handler.GetService<IDateTranslator>();
            var viewModel = new DateTranslatorVM(translator!, logger!);
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
