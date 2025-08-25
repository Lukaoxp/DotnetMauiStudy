using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class PerfilPage : ContentPage
{

    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private bool _loginPageDisplayed = false;

    public PerfilPage(ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        LblNomeUsuario.Text = Preferences.Get("usuarionome", string.Empty);
        _apiService = apiService;
        _validator = validator;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ImgBtnPerfil.Source = await GetImagemPerfil();
    }

    private async Task<string?> GetImagemPerfil()
    {
        string imagemPadrao = AppConfig.PerfilImagemPadrao;

        var (response, errorMessage) = await _apiService.GetImagemPerfilUsuario();

        // Lida com casos de erro
        if (errorMessage is not null)
        {
            switch (errorMessage)
            {
                case "Unauthorized":
                    if (!_loginPageDisplayed)
                    {
                        await DisplayLoginPage();
                        return null;
                    }
                    break;
                default:
                    await DisplayAlert("Erro", errorMessage ?? "N o foi poss vel obter a imagem.", "OK");
                    return imagemPadrao;
            }
        }

        if (response?.UrlImagem is not null)
        {
            return response.CaminhoImagem;
        }

        return imagemPadrao;
    }

    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator));
    }

    private async void ImgBtnPerfil_Clicked(object sender, EventArgs e)
    {
        try
        {
            var ImagemArray = await SelecionarImagemAsync();
            if (ImagemArray is null)
            {
                await DisplayAlert("Erro", "Não foi possível carregar a imagem", "Ok");
                return;
            }
            ImgBtnPerfil.Source = ImageSource.FromStream(() => new MemoryStream(ImagemArray));

            var response = await _apiService.UploadImagemUsuario(ImagemArray);
            if (response.Data)
            {
                await DisplayAlert("", "Imagem enviada com sucesso", "Ok");
            }
            else
            {
                await DisplayAlert("Erro", response.ErrorMessage ?? "Ocorreu um erro desconhecido", "Cancelar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro incesperado: {ex.Message}", "Ok");
        }
    }

    private async Task<byte[]?> SelecionarImagemAsync()
    {
        try
        {
            var arquivo = await MediaPicker.PickPhotoAsync();

            if (arquivo is null) return null;

            using (var stream = await arquivo.OpenReadAsync())
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Erro", "Funcionalidade não suportada no dispositivo", "Ok");
        }
        catch (PermissionException)
        {
            await DisplayAlert("Erro", "Permissões não concedidas para acessar a câmera ou galeria", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao selecionar a imagem: {ex.Message}", "Ok");
        }
        return null;
    }

    private void Pedidos_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PedidosPage(_apiService, _validator));
    }

    private void MinhaConta_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new MinhaContaPage(_apiService));
    }

    private void Perguntas_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new FaqPage());
    }

    private void BtnLogout_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("acesstoken", string.Empty);
        Application.Current!.MainPage = new NavigationPage(new LoginPage(_apiService, _validator));
    }
}