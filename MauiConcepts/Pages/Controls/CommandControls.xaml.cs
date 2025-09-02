namespace MauiConcepts.Pages;

public partial class CommandControls : ContentPage
{
    public CommandControls()
    {
        InitializeComponent();
    }

    private async void BtnDemo_Clicked(object sender, EventArgs e)
    {
        await LblDemo.RelRotateTo(360, 2000);
        await DisplayAlert("Alerta", "Label rotacionada", "OK");
    }

    private async void btnImgDemo_Clicked(object sender, EventArgs e)
    {
        await LblDemo.RelRotateTo(360, 5000);
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        SearchBar searchbar = (SearchBar)sender;
        await DisplayAlert("Pesquisando...", $"{searchbar.Text}", "Ok");
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {

    }
}