using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Demo.Mvvm.ViewModels
{
    public partial class ComNotifyViewModel : INotifyPropertyChanged
    {
        private string _mensagem;
        public string Mensagem
        {
            get { return _mensagem; }
            set
            {
                _mensagem = value;
                Notificar();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [RelayCommand]
        public void ButtonClick(string valor)
        {
            Mensagem = $"Bem-Vindo {valor}";
        }

        public void Notificar([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
