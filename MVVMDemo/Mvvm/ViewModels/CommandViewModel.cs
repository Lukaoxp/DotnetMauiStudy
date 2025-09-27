using CommunityToolkit.Mvvm.Input;

namespace MVVM_Demo.Mvvm.ViewModels
{
    public partial class CommandViewModel
    {
        [RelayCommand]
        public void ButtonClick()
        {
            Alerta("Clique do botão");
        }

        [RelayCommand]
        public void Search(string searchTerm)
        {
            Alerta(searchTerm);
        }

        public void Alerta(string mensagem)
        {
            App.Current?.MainPage?.DisplayAlert("Alerta", mensagem, "Ok", "Cancel");
        }
    }
}
