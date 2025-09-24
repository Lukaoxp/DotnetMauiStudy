using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiDemoDataBinding.Models
{
    public class Produto : INotifyPropertyChanged
    {
        private string nome = string.Empty;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        private decimal preco;

        public decimal Preco
        {
            get { return preco; }
            set
            {
                preco = value;
                OnPropertyChanged();
            }
        }

        private int estoque;

        public int Estoque
        {
            get { return estoque; }
            set
            {
                estoque = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
