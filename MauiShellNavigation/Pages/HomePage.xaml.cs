namespace MauiShellNavigation.Pages;

[QueryProperty(nameof(UserName), "username")]
public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private string username;

    public string UserName
    {
        get { return username; }
        set
        {
            username = value;
            LblUsername.Text = username;
        }
    }
}