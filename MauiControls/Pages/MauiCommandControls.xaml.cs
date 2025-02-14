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
}