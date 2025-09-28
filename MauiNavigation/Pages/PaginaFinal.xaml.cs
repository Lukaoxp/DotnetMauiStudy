namespace MauiNavigation.Pages;

public partial class PaginaFinal : ContentPage
{
    public PaginaFinal()
    {
        InitializeComponent();
    }

    private async void NavigateToFirstPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}