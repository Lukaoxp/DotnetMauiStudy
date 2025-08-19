using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;
using System.Collections.ObjectModel;

namespace AppLanches.Pages;

public partial class CarrinhoPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private readonly FavoritosService _favoritosService;
    private bool _loginPageDisplayed = false;
    private bool _isNavigatingToEmptyCartPage = false;

    public CarrinhoPage(ApiService apiService, IValidator validator, FavoritosService favoritosService)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
        _favoritosService = favoritosService;
    }

    public ObservableCollection<CarrinhoCompraItem> ItensCarrinhoCompra { get; set; } = [];

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (IsNavigatingToEmptyCartPage())
            return;

        bool hasItems = await GetItensCarrinhoCompra();

        if (hasItems)
        {
            ExibirEndereco();
        }
        else
        {
            await NavegarParaCarrinhoVazio();
        }
    }

    private async Task NavegarParaCarrinhoVazio()
    {
        LblEndereco.Text = string.Empty;
        _isNavigatingToEmptyCartPage = true;
        await Navigation.PushAsync(new CarrinhoVazioPage());
    }

    private void ExibirEndereco()
    {
        bool enderecoSalvo = Preferences.ContainsKey("endereco");
        if (enderecoSalvo)
        {
            string nome = Preferences.Get("nome", string.Empty);
            string endereco = Preferences.Get("endereco", string.Empty);
            string telefone = Preferences.Get("telefone", string.Empty);

            LblEndereco.Text = $"{nome}\n{endereco}\n{telefone}";
        }
        else
        {
            LblEndereco.Text = "Informe seu endereço";
        }
    }

    private bool IsNavigatingToEmptyCartPage()
    {
        if (_isNavigatingToEmptyCartPage)
        {
            _isNavigatingToEmptyCartPage = false;
            return true;
        }
        return false;
    }

    private async Task<bool> GetItensCarrinhoCompra()
    {
        try
        {
            var usuarioId = Preferences.Get("usuarioid", 0);
            var (itensCarrinhoCompra, errorMessage) = await _apiService.GetItensCarrinhoCompra(usuarioId);
            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return false;
            }

            if (itensCarrinhoCompra == null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter os itens do carrinho de compras.", "OK");
                return false;
            }

            ItensCarrinhoCompra.Clear();
            foreach (var item in itensCarrinhoCompra)
            {
                ItensCarrinhoCompra.Add(item);
            }

            CvCarrinho.ItemsSource = ItensCarrinhoCompra;
            AtualizaPrecoTotal();

            if (!ItensCarrinhoCompra.Any())
                return false;

            return true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro inesperado: {ex.Message}", "OK");
            return false;
        }
    }

    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator, _favoritosService));
    }

    private void AtualizaPrecoTotal()
    {
        try
        {
            var precoTotal = ItensCarrinhoCompra.Sum(item => item.PrecoUnitario * item.Quantidade);
            LblPrecoTotal.Text = precoTotal.ToString();
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", $"Ocorreu um erro ao atualizar o preço: {ex.Message}", "OK");
        }
    }
    private async void BtnIncrementar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is CarrinhoCompraItem itemCarrinho)
        {
            itemCarrinho.Quantidade++;
            AtualizaPrecoTotal();
            await _apiService.AtualizaQuantidadeItemCarrinho(itemCarrinho.ProdutoId, "aumentar");
        }
    }

    private async void BtnDecrementar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is CarrinhoCompraItem itemCarrinho && itemCarrinho.Quantidade > 1)
        {
            itemCarrinho.Quantidade--;
            AtualizaPrecoTotal();
            await _apiService.AtualizaQuantidadeItemCarrinho(itemCarrinho.ProdutoId, "diminuir");
        }
    }

    private async void BtnDeletar_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.BindingContext is CarrinhoCompraItem itemCarrinho)
        {
            bool resposta = await DisplayAlert("Confirmação", $"Tem certeza que deseja excluir este item do carrinho?", "Sim", "Não");
            if (resposta)
            {
                ItensCarrinhoCompra.Remove(itemCarrinho);
                AtualizaPrecoTotal();
                await _apiService.AtualizaQuantidadeItemCarrinho(itemCarrinho.ProdutoId, "deletar");
            }
        }
    }

    private void BtnEditaEndereco_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EnderecoPage());
    }

    private async void TapConfirmarPedido_Tapped(object sender, TappedEventArgs e)
    {
        if (ItensCarrinhoCompra == null || !ItensCarrinhoCompra.Any())
        {
            await DisplayAlert("Atenção", "Seu carrinho está vazio ou o pedido já foi confirmado", "OK");
            return;
        }

        var pedido = new Pedido()
        {
            Endereco = Preferences.Get("endereco", string.Empty),
            UsuarioId = Preferences.Get("usuarioid", 0),
            ValorTotal = Convert.ToDecimal(LblPrecoTotal.Text)
        };

        var response = await _apiService.ConfirmarPedido(pedido);

        if (response.HasError)
        {
            if (response.ErrorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return;
            }
            await DisplayAlert("Erro", $"Algo deu errado: {response.ErrorMessage}", "OK");
            return;
        }

        ItensCarrinhoCompra.Clear();
        LblEndereco.Text = "Informe seu endereço";
        LblPrecoTotal.Text = "0.00";

        await Navigation.PushAsync(new PedidoConfirmadoPage());
    }
}