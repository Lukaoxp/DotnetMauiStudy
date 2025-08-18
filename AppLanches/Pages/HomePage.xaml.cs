using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class HomePage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private bool _loginPageDisplayed = false;
    private bool _isDataLoaded = false;

    public HomePage(ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        LblNomeUsuario.Text = $"Olá {Preferences.Get("usuarionome", string.Empty)}";
        _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        _validator = validator;
        Title = AppConfig.tituloHomePage;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!_isDataLoaded)
        {
            await LoadDataAsync();
            _isDataLoaded = true;
        }
    }

    private async Task LoadDataAsync()
    {
        var categoriasTask = GetListaCategorias();
        var maisVendidosTask = GetMaisVendidos();
        var popularesTask = GetPopulares();
        await Task.WhenAll(categoriasTask, maisVendidosTask, popularesTask);
    }

    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator));
    }

    private async Task<IEnumerable<Categoria>> GetListaCategorias()
    {
        try
        {
            var (categorias, errorMessage) = await _apiService.GetCategorias();

            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return [];
            }

            if (categorias == null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter as categorias.", "OK");
                return [];
            }

            CvCategorias.ItemsSource = categorias;
            return categorias;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro inesperado: {ex.Message}", "OK");
            return [];
        }
    }
    private async Task<IEnumerable<Produto>> GetMaisVendidos()
    {
        try
        {
            var (produtos, errorMessage) = await _apiService.GetProdutos("maisvendido", string.Empty);

            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return [];
            }

            if (produtos == null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter os produtos mais vendidos.", "OK");
                return [];
            }

            CvMaisVendidos.ItemsSource = produtos;
            return produtos;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro inesperado: {ex.Message}", "OK");
            return [];
        }
    }

    private async Task<IEnumerable<Produto>> GetPopulares()
    {
        try
        {
            var (produtos, errorMessage) = await _apiService.GetProdutos("popular", string.Empty);

            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return [];
            }

            if (produtos == null)
            {
                await DisplayAlert("Erro", errorMessage ?? "Não foi possível obter os produtos populares.", "OK");
                return [];
            }

            CvMaisPopulares.ItemsSource = produtos;
            return produtos;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro inesperado: {ex.Message}", "OK");
            return [];
        }
    }

    private void CvCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Categoria;

        if (currentSelection is null) return;

        Navigation.PushAsync(new ListaProdutosPage(currentSelection.Id, currentSelection.Nome!, _apiService, _validator));

        ((CollectionView)sender).SelectedItem = null; // Deselect the item after navigation
    }

    private void CvMaisVendidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is CollectionView collectionView)
        {
            NavigateToProdutoDetalhesPage(collectionView, e);
        }
    }

    private void CvMaisPopulares_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is CollectionView collectionView)
        {
            NavigateToProdutoDetalhesPage(collectionView, e);
        }
    }

    private void NavigateToProdutoDetalhesPage(CollectionView collectionView, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Produto;

        if (currentSelection is null) return;

        Navigation.PushAsync(new ProdutoDetalhesPage(currentSelection.Id, currentSelection.Nome!, _apiService, _validator));
        collectionView.SelectedItem = null; // Deselect the item after navigation
    }
}