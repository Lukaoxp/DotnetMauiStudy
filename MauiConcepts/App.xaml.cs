using MauiConcepts.Layouts;

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
            //MainPage = new TabbedPageDemo();

            // StackLayout
            //MainPage = new StackLayoutDemo();

            // Grid
            MainPage = new NavigationPage(new GridDemo());
        }
    }
}
