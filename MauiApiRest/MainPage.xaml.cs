using MauiApiRest.ViewModels;

namespace MauiApiRest
{
    public partial class MainPage : ContentPage
    {
        private CategoriaViewModel _vm = new CategoriaViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }
    }
}
