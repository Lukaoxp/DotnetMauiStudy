namespace MauiNavigation.Pages;

public partial class DetalhesAlunoPage : ContentPage
{
    public DetalhesAlunoPage()
    {
        InitializeComponent();
    }

    public DetalhesAlunoPage(string nome)
    {
        InitializeComponent();
        NomeLabel.Text = nome;
    }
}