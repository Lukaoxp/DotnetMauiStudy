using MauiShellNavigation.Pages;

namespace MauiShellNavigation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(Page2), typeof(Page2));
        }
    }
}
