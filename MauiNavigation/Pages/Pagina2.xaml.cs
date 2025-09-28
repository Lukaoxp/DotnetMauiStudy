namespace MauiNavigation.Pages;

public partial class Pagina2 : ContentPage
{
    public Pagina2()
    {
        InitializeComponent();
    }

    private async void NavigateToFirstPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void NavigateToLastPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaFinal());
    }
}