namespace MauiNavigation.Pages;

public partial class AlunosPage : ContentPage
{
    public AlunosPage()
    {
        InitializeComponent();
    }

    private async void button1_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalhesAlunoPage(txtNome.Text));
    }
}