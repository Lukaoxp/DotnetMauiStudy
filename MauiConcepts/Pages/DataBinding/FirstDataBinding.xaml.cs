using MauiConcepts.Models;

namespace MauiConcepts.Pages.DataBinding;

public partial class FirstDataBinding : ContentPage
{
    public FirstDataBinding()
    {
        InitializeComponent();
    }

    private void SetBindBtn_Clicked(object sender, EventArgs e)
    {
        Produto produto = new()
        {
            Nome = "Iphone",
            Preco = 5000.0m,
            Estoque = 5
        };

        Binding produtoBinding = new Binding();
        produtoBinding.Source = produto;
        produtoBinding.Path = "Nome";

        lblNome.SetBinding(Label.TextProperty, produtoBinding);
    }
}