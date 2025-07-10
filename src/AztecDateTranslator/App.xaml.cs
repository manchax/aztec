namespace AztecDateTranslator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            const int winW = 600;
            const int winH = 745;
            return new Window(new AppShell())
            {
                Width = winW,
                Height = winH
            };
        }
    }
}