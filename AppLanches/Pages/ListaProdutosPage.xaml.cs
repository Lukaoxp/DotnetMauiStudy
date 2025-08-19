using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class ListaProdutosPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private readonly FavoritosService _favoritosService;
    private int _categoriaId;
    private bool _loginPageDisplayed = false;

    public ListaProdutosPage(int categoriaId, string categoriaNome, ApiService apiService, IValidator validator, FavoritosService favoritosService)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
        _favoritosService = favoritosService;
        _categoriaId = categoriaId;
        Title = categoriaNome ?? "Produtos";
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetListaProdutos(_categoriaId);
    }

    private async Task<IEnumerable<Produto>> GetListaProdutos(int categoriaId)
    {
        try
        {
            var (produtos, errorMessage) = await _apiService.GetProdutos("categoria", categoriaId.ToString());
            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return [];
            }

            if (produtos == null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter os produtos da categoria.", "OK");
                return [];
            }

            CvProdutos.ItemsSource = produtos;
            return produtos;
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
        await Navigation.PushAsync(new LoginPage(_apiService, _validator, _favoritosService));
    }

    private void CvProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Produto;
        if (currentSelection is null) return;

        Navigation.PushAsync(new ProdutoDetalhesPage(currentSelection.Id, currentSelection.Nome!, _apiService, _validator, _favoritosService));

        ((CollectionView)sender).SelectedItem = null;
    }
}