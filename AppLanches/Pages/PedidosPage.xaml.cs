using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class PedidosPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private readonly FavoritosService _favoritosService;
    private bool _loginPageDisplayed;

    public PedidosPage(ApiService apiService, IValidator validator, FavoritosService favoritosService)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
        _favoritosService = favoritosService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        GetListaPedidos();
    }

    private async void GetListaPedidos()
    {
        try
        {
            var (pedidos, errorMessage) = await _apiService.GetPedidosPorUsuario(Preferences.Get("usuarioid", 0));
            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return;
            }
            else if (errorMessage == "NotFound")
            {
                await DisplayAlert("Aviso", "Não existem pedidos para o cliente", "OK");
                return;
            }
            else if (pedidos is null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter pedidos", "OK");
                return;
            }
            else
            {
                CvPedidos.ItemsSource = pedidos;
            }
        }
        catch (Exception)
        {
            await DisplayAlert("Erro", "Ocorreu um erro ao obter pedidos. Tente novamente mais tarde.", "OK");
        }

    }

    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator, _favoritosService));
    }

    private void CvPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as PedidoPorUsuario;

        if (selectedItem == null) return;

        Navigation.PushAsync(new PedidoDetalhesPage(selectedItem.Id, selectedItem.PedidoTotal, _apiService, _validator, _favoritosService));

        ((CollectionView)sender).SelectedItem = null;
    }
}