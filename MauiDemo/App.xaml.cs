namespace MauiDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var page = new NavigationPage(new GridLayoutDemo());
            //page.BarBackground = Colors.DarkBlue;

            //MainPage = page;
            MainPage = new NavigationPage(new FlexlayoutDemo());
        }
    }
}
