namespace MauiNavigation.Pages;

public partial class ModalPage : ContentPage
{
    public ModalPage()
    {
        InitializeComponent();
    }

    private async void Btn1_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    /// <summary>
    /// Evita o retorno via clique do botão de voltar do android
    /// </summary>
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}