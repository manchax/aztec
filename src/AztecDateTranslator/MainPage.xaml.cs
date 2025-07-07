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
            SetVisibility(DeviceDisplay.Current.MainDisplayInfo.Orientation);
            DeviceDisplay.Current.MainDisplayInfoChanged += (_, e)
                => SetVisibility(e.DisplayInfo.Orientation);
        }

        private void SetVisibility(DisplayOrientation orientation)
        {
            LandscapePanel1.IsVisible = DisplayOrientation.Landscape == orientation;
            PortraitPanel1.IsVisible = DisplayOrientation.Portrait == orientation;
        }
    }
}
