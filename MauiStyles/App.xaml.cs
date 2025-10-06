namespace MauiStyles
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new DynamicStylePage();
            MainPage = new StyleClassPage();
        }
    }
}
