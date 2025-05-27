using AppLanches.Services;

namespace AppLanches.Pages;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _apiService;
    public LoginPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }
    private async void BtnSignIn_Clicked(object sender, EventArgs e)
    {
        var response = await _apiService.Login(EntEmail.Text, EntPassword.Text);
        if (!response.HasError)
        {
            await DisplayAlert("Aviso", "Sua conta foi criada com sucesso!", "OK");
            await Navigation.PushAsync(new LoginPage(_apiService));
        }
        else
        {
            await DisplayAlert("Erro", "Algo deu errado", "OK");
        }
    }

    private async void TapRegister_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new InscricaoPage(_apiService));
    }

}