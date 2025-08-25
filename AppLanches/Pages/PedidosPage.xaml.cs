using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class PedidosPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private bool _loginPageDisplayed;

    public PedidosPage(ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
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
            loadPedidosIndicator.IsRunning = true;
            loadPedidosIndicator.IsVisible = true;

            var (pedidos, errorMessage) = await _apiService.GetPedidosPorUsuario(Preferences.Get("usuarioid", 0));
            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return;
            }
            else if (errorMessage == "NotFound")
            {
                await DisplayAlert("Aviso", "N�o existem pedidos para o cliente", "OK");
                return;
            }
            else if (pedidos is null)
            {
                await DisplayAlert("Erro", errorMessage ?? "N�o foi poss�vel obter pedidos", "OK");
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
        finally
        {
            loadPedidosIndicator.IsRunning = false;
            loadPedidosIndicator.IsVisible = false;
        }

    }

    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator));
    }

    private void CvPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as PedidoPorUsuario;

        if (selectedItem == null) return;

        Navigation.PushAsync(new PedidoDetalhesPage(selectedItem.Id, selectedItem.PedidoTotal, _apiService, _validator));

        ((CollectionView)sender).SelectedItem = null;
    }
}