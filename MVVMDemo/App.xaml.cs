using MVVM_Demo.Mvvm.Views;

namespace MVVM_Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ComNotifyView();
        }
    }
}
