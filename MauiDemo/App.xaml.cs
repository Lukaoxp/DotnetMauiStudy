namespace MauiDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navPage = new NavigationPage(new MinhaPagina());

            navPage.BarBackground = Colors.Blue;
            navPage.BarTextColor = Colors.Beige;

            MainPage = new TabbedPageDemo();
        }
    }
}
