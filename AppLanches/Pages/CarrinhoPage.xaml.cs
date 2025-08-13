using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;
using System.Collections.ObjectModel;

namespace AppLanches.Pages;

public partial class CarrinhoPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private bool _loginPageDisplayed = false;

    public CarrinhoPage(ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
    }

    public ObservableCollection<CarrinhoCompraItem> ItensCarrinhoCompra { get; set; } = [];

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetItensCarrinhoCompra();
    }

    private async Task<IEnumerable<CarrinhoCompraItem>> GetItensCarrinhoCompra()
    {
        try
        {
            var usuarioId = Preferences.Get("usuarioid", 0);
            var (itensCarrinhoCompra, errorMessage) = await _apiService.GetItensCarrinhoCompra(usuarioId);
            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return [];
            }

            if (itensCarrinhoCompra == null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter os itens do carrinho de compras.", "OK");
                return [];
            }

            ItensCarrinhoCompra.Clear();
            foreach (var item in itensCarrinhoCompra)
            {
                ItensCarrinhoCompra.Add(item);
            }

            CvCarrinho.ItemsSource = ItensCarrinhoCompra;
            AtualizaPrecoTotal();
            return itensCarrinhoCompra;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro inesperado: {ex.Message}", "OK");
            return [];
        }
    }

    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator));
    }

    private void AtualizaPrecoTotal()
    {
        decimal precoTotal = 0;
        foreach (var item in ItensCarrinhoCompra)
        {
            precoTotal += item.PrecoUnitario * item.Quantidade;
        }
        LblPrecoTotal.Text = $"{precoTotal:F2}";
    }
}