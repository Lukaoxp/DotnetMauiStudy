using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;



public partial class ProdutoDetalhesPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private readonly FavoritosService _favoritosService;
    private int _produtoId;
    private string? _imagemUrl;
    private bool _loginPageDisplayed = false;

    public ProdutoDetalhesPage(int produtoId, string produtoNome, ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
        _favoritosService = ServiceFactory.CreateFavoritosService();
        _produtoId = produtoId;
        Title = produtoNome ?? "Detalhes do Produto";
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetProdutoDetalhes(_produtoId);
        AtualizaFavoritoButton();
    }

    private async Task<Produto?> GetProdutoDetalhes(int produtoId)
    {
        try
        {
            var (produtoDetalhe, errorMessage) = await _apiService.GetDetalheProduto(produtoId);

            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return null;
            }

            if (produtoDetalhe is null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter os detalhes do produto.", "OK");
                return null;
            }
            else
            {
                _imagemUrl = produtoDetalhe.CaminhoImagem;
                ImagemProduto.Source = _imagemUrl;
                LblProdutoNome.Text = produtoDetalhe.Nome;
                LblProdutoPreco.Text = produtoDetalhe.Preco.ToString();
                LblProdutoDescricao.Text = produtoDetalhe.Detalhe;
                LblPrecoTotal.Text = produtoDetalhe.Preco.ToString();
            }
            return produtoDetalhe;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro inesperado: {ex.Message}", "OK");
            return null;
        }
    }
    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator));
    }

    private void CvProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Produto;
        if (currentSelection is null) return;

        Navigation.PushAsync(new ProdutoDetalhesPage(currentSelection.Id, currentSelection.Nome!, _apiService, _validator));

        ((CollectionView)sender).SelectedItem = null;
    }

    private async void ImagemBtnFavorito_Clicked(object sender, EventArgs e)
    {
        try
        {
            var existeFavorito = await _favoritosService.ReadAsync(_produtoId);
            if (existeFavorito != null)
            {
                await _favoritosService.DeleteAsync(existeFavorito);
            }
            else
            {
                var produtoFavorito = new ProdutoFavorito
                {
                    ProdutoId = _produtoId,
                    IsFavorito = true,
                    Detalhe = LblProdutoDescricao.Text,
                    Nome = LblProdutoNome.Text,
                    Preco = Convert.ToDecimal(LblProdutoPreco.Text),
                    ImageUrl = _imagemUrl
                };

                await _favoritosService.CreateAsync(produtoFavorito);
            }
            AtualizaFavoritoButton();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocoreu um erro: {ex.Message}", "OK");
        }
    }

    private async void AtualizaFavoritoButton()
    {
        var existeFavorito = await _favoritosService.ReadAsync(_produtoId);

        ImagemBtnFavorito.Source = existeFavorito is not null ? "heartfill" : "heart";
    }

    private void BtnRemove_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(LblQuantidade.Text, out int quantidade) && decimal.TryParse(LblProdutoPreco.Text, out decimal precoUnitario))
        {
            quantidade = Math.Max(1, quantidade - 1);
            LblQuantidade.Text = quantidade.ToString();


            var precoTotal = quantidade * precoUnitario;
            LblPrecoTotal.Text = precoTotal.ToString();

        }
        else
        {
            DisplayAlert("Erro", "Valores inválidos", "OK");
        }
    }

    private void BtnAdiciona_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(LblQuantidade.Text, out int quantidade) && decimal.TryParse(LblProdutoPreco.Text, out decimal precoUnitario))
        {
            quantidade++;
            LblQuantidade.Text = quantidade.ToString();

            var precoTotal = quantidade * precoUnitario;
            LblPrecoTotal.Text = precoTotal.ToString("F2");
        }
        else
        {
            DisplayAlert("Erro", "Valores inválidos", "OK");
        }
    }

    private async void BtnIncluirNoCarrinho_Clicked(object sender, EventArgs e)
    {
        try
        {
            var carrinhoCompra = new CarrinhoCompra()
            {
                Quantidade = Convert.ToInt32(LblQuantidade.Text),
                PrecoUnitario = Convert.ToDecimal(LblProdutoPreco.Text),
                ValorTotal = Convert.ToDecimal(LblPrecoTotal.Text),
                ProdutoId = _produtoId,
                ClienteId = Preferences.Get("usuarioid", 0)
            };
            var response = await _apiService.AdicionaItemNoCarrinho(carrinhoCompra);
            if (response.Data)
            {
                await DisplayAlert("Sucesso", "Item adicionado ao carrinho!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro", $"Falha ao adicionar item: {response.ErrorMessage}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
        }
    }
}