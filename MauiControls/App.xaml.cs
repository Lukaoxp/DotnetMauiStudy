using MauiControls.Pages;

namespace MauiControls
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = new NavigationPage(new MauiSetValueControls());
            page.BarBackgroundColor = Color.FromRgba("#2196F3");
            page.BarTextColor = Color.FromRgba("#FEFEFE");
            MainPage = page;
        }
    }
}
