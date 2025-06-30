using AztecDateTranslator.ViewModels;

namespace AztecDateTranslator
{
    public partial class MainPage
    {
        public MainPage()
        {
            var app = Application.Current!;
            var viewModel = app.Handler.GetService<DateTranslator>() ??
                throw new NullReferenceException();
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
