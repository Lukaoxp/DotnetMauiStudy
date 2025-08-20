using AppLanches.Pages;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches
{
    public partial class AppShell : Shell
    {
        private readonly ApiService _apiService;
        private readonly IValidator _validator;
        private readonly FavoritosService _favoritosService;

        public AppShell(ApiService apiService, IValidator validator, FavoritosService favoritosService)
        {
            InitializeComponent();
            _apiService = apiService;
            _validator = validator;
            _favoritosService = favoritosService;

            ConfigureShell();
        }

        private void ConfigureShell()
        {
            var homePage = new HomePage(_apiService, _validator, _favoritosService);
            var carrinhoPage = new CarrinhoPage(_apiService, _validator, _favoritosService);
            var favoritosPage = new FavoritosPage(_apiService, _validator, _favoritosService);
            var perfilPage = new PerfilPage(_apiService, _validator, _favoritosService);

            Items.Add(new TabBar
            {
                Items =
                {
                    new ShellContent{Title = "Home", Icon = "home", Content = homePage},
                    new ShellContent{Title = "Carrinho", Icon = "cart", Content = carrinhoPage},
                    new ShellContent{Title = "Favoritos", Icon = "heart", Content = favoritosPage},
                    new ShellContent{Title = "Perfil", Icon = "profile", Content = perfilPage}
                }
            });
        }
    }
}
