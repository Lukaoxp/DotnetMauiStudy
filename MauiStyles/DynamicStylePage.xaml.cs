namespace MauiStyles;

public partial class DynamicStylePage : ContentPage
{
    public DynamicStylePage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Resources["dynamicStyle"] = Resources["midnightStyle"];
    }
}