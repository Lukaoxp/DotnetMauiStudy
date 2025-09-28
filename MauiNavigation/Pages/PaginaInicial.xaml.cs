namespace MauiNavigation.Pages;

public partial class PaginaInicial : ContentPage
{
    public PaginaInicial()
    {
        InitializeComponent();
    }

    private async void NavigateToPage2Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pagina2());
    }

    private async void AbrirModalButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ModalPage());
    }
}