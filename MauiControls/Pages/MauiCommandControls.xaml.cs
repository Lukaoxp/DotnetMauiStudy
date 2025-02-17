namespace MauiControls.Pages;

public partial class MauiCommandControls : ContentPage
{
    public MauiCommandControls()
    {
        InitializeComponent();
    }

    private async void btnDemo_Clicked(object sender, EventArgs e)
    {
        await lblDemo.RotateTo(360, 2000);
        lblDemo.Rotation = 0;
    }

    private void btnImgDemo_Clicked(object sender, EventArgs e)
    {

    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton selectedRadioButton = (RadioButton)sender;
        if (LblPets != null)
        {
            LblPets.Text = $"Selecionou: {selectedRadioButton.Value}";
            LblPets.FontSize = 20;
        }
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        await DisplayAlert("Pesquisando...", $"{searchBar.Text}", "Ok");
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {

    }
}