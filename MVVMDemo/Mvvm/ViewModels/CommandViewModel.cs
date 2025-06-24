using CommunityToolkit.Mvvm.Input;

namespace MVVM_Demo.Mvvm.ViewModels
{
    public partial class CommandViewModel
    {
        public string SearchTerm { get; set; } = string.Empty;

        [RelayCommand]
        private void ExibirAlerta()
        {
            App.Current.MainPage.DisplayAlert("Alerta", "Mensagem de alerta", "OK");
        }

        [RelayCommand]
        private void Search(object searchtext)
        {
            Alerta(searchtext.ToString());
        }

        private void Alerta(string? mensagem)
        {
            App.Current.MainPage.DisplayAlert("Alerta", mensagem, "OK");
        }
    }
}
