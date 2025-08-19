using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class InscricaoPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private readonly FavoritosService _favoritosService;

    public InscricaoPage(ApiService apiService, IValidator validator, FavoritosService favoritosService)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
        _favoritosService = favoritosService;
    }

    private async void BtnSignup_Clicked(object sender, EventArgs e)
    {
        if (await _validator.Validar(EntNome.Text, EntEmail.Text, EntTelefone.Text, EntPassword.Text))
        {

            var response = await _apiService.RegistrarUsuario(EntNome.Text, EntEmail.Text, EntTelefone.Text, EntPassword.Text);
            if (!response.HasError)
            {
                await DisplayAlert("Aviso", "Sua conta foi criada com sucesso!", "OK");
                await Navigation.PushAsync(new LoginPage(_apiService, _validator, _favoritosService));
            }
            else
            {
                await DisplayAlert("Erro", "Algo deu errado", "OK");
            }
        }
        else
        {
            string mensagemErro = string.Empty;
            mensagemErro += _validator.NomeErro != null ? $"\n- {_validator.NomeErro}" : mensagemErro;
            mensagemErro += _validator.EmailErro != null ? $"\n- {_validator.EmailErro}" : mensagemErro;
            mensagemErro += _validator.TelefoneErro != null ? $"\n- {_validator.TelefoneErro}" : mensagemErro;
            mensagemErro += _validator.SenhaErro != null ? $"\n- {_validator.SenhaErro}" : mensagemErro;

            await DisplayAlert("Erro", mensagemErro, "OK");
        }
    }

    private async void TapLogin_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage(_apiService, _validator, _favoritosService));
    }
}