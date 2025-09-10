using MauiDemoDataBinding.Models;

namespace MauiDemoDataBinding
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Produto produto = new()
            {
                Nome = "Iphone 5",
                Preco = 5000.0m,
                Quantidade = 2
            };

            Binding produtoBinding = new()
            {
                Source = produto,
                Path = "Nome"
            };
            lblNome.SetBinding(Label.TextProperty, produtoBinding);
        }
    }

}
