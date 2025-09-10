namespace MauiDemoDataBinding
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    Produto produto = new()
        //    {
        //        Nome = "Iphone 5",
        //        Preco = 5000.0m,
        //        Estoque = 2
        //    };

        //    Binding nomeBinding = new()
        //    {
        //        Source = produto,
        //        Path = "Nome",
        //        StringFormat = "Produto: {0}"
        //    };

        //    Binding precoBinding = new()
        //    {
        //        Source = produto,
        //        Path = "Preco",
        //        StringFormat = "Preço: {0}"
        //    };

        //    Binding estoqueBinding = new()
        //    {
        //        Source = produto,
        //        Path = "Estoque",
        //        StringFormat = "Estoque: {0}"
        //    };

        //    lblNome.SetBinding(Label.TextProperty, nomeBinding);
        //    lblPreco.SetBinding(Label.TextProperty, precoBinding);
        //    lblEstoque.SetBinding(Label.TextProperty, estoqueBinding);
        //}
    }
}
