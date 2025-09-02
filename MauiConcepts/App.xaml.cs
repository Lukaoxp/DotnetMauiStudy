using MauiConcepts.Pages.Controls;

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

            // Stack Layout
            //MainPage = new StackLayoutDemo();

            // Grid
            //MainPage = new NavigationPage(new GridDemo());

            // Flex Layout
            //MainPage = new NavigationPage(new FlexLayoutDemo());

            // Absolute Layout
            //MainPage = new NavigationPage(new AbsoluteLayoutDemo());

            // Presentation Controls
            //MainPage = new NavigationPage(new PresentationControlsDemo());

            // Command Controls
            //MainPage = new NavigationPage(new CommandControls());

            // Controles que definem valores
            MainPage = new NavigationPage(new ValueDefiningControls());
        }
    }
}
