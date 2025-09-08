namespace MauiConcepts.Pages.Controls;

public partial class EditControls : ContentPage
{
    public EditControls()
    {
        InitializeComponent();
        this.BindingContext = this;
        this.IsBusy = false;
    }

    //private async void Button_Clicked(object sender, EventArgs e)
    //{
    //    if (progressBar is not null)
    //    {
    //        await progressBar.ProgressTo(progressBar.Progress + 0.25, 1000, Easing.CubicIn);
    //    }
    //}

    private void BtnLogin_Clicked(object sender, EventArgs e)
    {
        this.IsBusy = true;
    }
}