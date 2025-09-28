using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text;

namespace MVVM_Demo.Mvvm.ViewModels
{
    public partial class ComToolkitViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Endereco))]
        private string nome;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Endereco))]
        private string sobrenome;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Endereco))]
        private string rua;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Endereco))]
        private string cep;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Endereco))]
        private string cidade;

        public string Endereco
        {
            get
            {
                StringBuilder stringBuilder = new();
                stringBuilder.AppendLine($"{Nome} {Sobrenome}")
                    .AppendLine(Rua)
                    .AppendLine($"{Cep} - {Cidade}");
                return stringBuilder.ToString();
            }
        }

        [RelayCommand]
        public void ImprimirEndereco(string endereco)
        {
            App.Current?.MainPage?.DisplayAlert("Endereço", endereco, "Ok");
        }
    }
}
