using AppLanches.Models;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;



public partial class ProdutoDetalhesPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private int _produtoId;
    private bool _loginPageDisplayed = false;

    public ProdutoDetalhesPage(int produtoId, string produtoNome, ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
        _produtoId = produtoId;
        Title = produtoNome ?? "Detalhes do Produto";
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetProdutoDetalhes(_produtoId);
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
                await DisplayAlert("Erro", errorMessage ?? "N�o foi poss�vel obter os detalhes do produto.", "OK");
                return null;
            }
            else
            {
                ImagemProduto.Source = produtoDetalhe.CaminhoImagem;
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

    private void ImagemBtnFavorito_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnRemove_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnAdiciona_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnIncluirNoCarrinho_Clicked(object sender, EventArgs e)
    {

    }
}