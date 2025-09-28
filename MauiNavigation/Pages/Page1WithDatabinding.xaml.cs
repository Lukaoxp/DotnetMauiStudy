using MauiNavigation.ViewModels;

namespace MauiNavigation.Pages;

public partial class Page1WithDatabinding : ContentPage
{
    public Page1WithDatabinding()
    {
        InitializeComponent();
    }

    private async void btn1_Clicked(object sender, EventArgs e)
    {
        var pessoa = new PessoaViewModel()
        {
            Nome = txtNome.Text,
            Idade = txtIdade.Text,
            Email = txtEmail.Text
        };
        await Navigation.PushAsync(new Page2WithDataBinding()
        {
            BindingContext = pessoa
        });
    }
}