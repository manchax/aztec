using AztecDateTranslator.ViewModels;
using Microsoft.Extensions.Logging;

namespace AztecDateTranslator
{
    public partial class MainPage
    {
        public MainPage()
        {
            var app = (AztecDateTranslator.App)App.Current!;
            var logger = app!.Handler.GetService<ILogger<DateTranslator>>();
            var translator = app.Handler.GetService<IDateTranslator>();
            var viewModel = new DateTranslator(translator!, logger!);
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
