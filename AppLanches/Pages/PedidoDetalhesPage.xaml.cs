using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class PedidoDetalhesPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private readonly FavoritosService _favoritosService;
    private bool _loginPageDisplayed = false;

    public PedidoDetalhesPage(int pedidoId, decimal pedidoTotal, ApiService apiService, IValidator validator, FavoritosService favoritosService)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
        _favoritosService = favoritosService;

        LblPrecoTotal.Text = "R$" + pedidoTotal;
        GetPedidoDetalhe(pedidoId);

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void GetPedidoDetalhe(int pedidoId)
    {
        try
        {
            var (pedidoDetalhes, errorMessage) = await _apiService.GetPedidoDetalhes(pedidoId);
            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return;
            }

            if (pedidoDetalhes is null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter detalhes do pedido", "OK");
                return;
            }
            else
            {
                CvPedidoDetalhes.ItemsSource = pedidoDetalhes;
            }

        }
        catch (Exception)
        {
            await DisplayAlert("Erro", "Ocorre um erro ao obter os detalhes. Tente novamnte mais tarde", "OK");
        }
    }
    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator, _favoritosService));
    }
}