using MauiDemoDataBinding.Models;

namespace MauiDemoDataBinding.Pages;

public partial class NotifyBinding : ContentPage
{
    Produto produto = new();
    public NotifyBinding()
    {
        InitializeComponent();
        produto = new Produto()
        {
            Nome = "Iphone 5",
            Preco = 500.0m,
            Estoque = 5
        };
        BindingContext = produto;
    }

    private void btnAtualiza_Clicked(object sender, EventArgs e)
    {
        produto.Nome = "Galaxy S5";
        produto.Preco = 300.0m;
        produto.Estoque = 150;
    }
}