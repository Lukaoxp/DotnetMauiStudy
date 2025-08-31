using MauiConcepts.Pages;

namespace MauiConcepts
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            // Flyout page
            //MainPage = new FlyoutPageDemo();

            // Tabbed page
            MainPage = new TabbedPageDemo();
        }
    }
}
