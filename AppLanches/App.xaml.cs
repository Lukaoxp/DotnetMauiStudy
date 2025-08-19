using AppLanches.Pages;
using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches
{
    public partial class App : Application
    {
        private readonly ApiService _apiService;
        private readonly IValidator _validator;
        private readonly FavoritosService _favoritosService;

        public App(ApiService apiService, IValidator validator, FavoritosService favoritosService)
        {
            InitializeComponent();

            _apiService = apiService;
            _validator = validator;
            _favoritosService = favoritosService;

            SetMainPage();
        }

        private void SetMainPage()
        {
            var accessToken = Preferences.Get("accesstoken", string.Empty);
            if (string.IsNullOrEmpty(accessToken))
            {
                MainPage = new NavigationPage(new LoginPage(_apiService, _validator, _favoritosService));
                return;
            }
            MainPage = new AppShell(_apiService, _validator, _favoritosService);
        }
    }
}
