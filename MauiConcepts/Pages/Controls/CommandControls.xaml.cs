namespace MauiConcepts.Pages;

public partial class CommandControls : ContentPage
{
    public CommandControls()
    {
        InitializeComponent();
    }

    private async void BtnDemo_Clicked(object sender, EventArgs e)
    {
        await LblDemo.RelRotateTo(360, 2000, Easing.CubicIn);
        await DisplayAlert("Alerta", "teste", "ok");
    }
}