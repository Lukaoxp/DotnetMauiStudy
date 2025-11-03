using CommunityToolkit.Mvvm.ComponentModel;
using MauiSQLite.MVVM.Models;
using MauiSQLite.Services;
using System.Windows.Input;

namespace MauiSQLite.MVVM.ViewModels
{
    public partial class AgendaViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Contato> _contatos;

        [ObservableProperty]
        private Contato _contatoAtual;

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DisplayCommand { get; set; }

        public AgendaViewModel(IAgendaService contatoRepository)
        {
            ContatoAtual = new();

            AddCommand = new Command(async () =>
            {
                await contatoRepository.InitializeAsync();
                await contatoRepository.AddContato(ContatoAtual);
                await Refresh(contatoRepository);
            });

            UpdateCommand = new Command(async () =>
            {
                await contatoRepository.InitializeAsync();
                await contatoRepository.UpdateContato(ContatoAtual);
                await Refresh(contatoRepository);
            });

            DeleteCommand = new Command(async () =>
            {
                await contatoRepository.InitializeAsync();

                // .NET 9 MAUI - Forma recomendada para single-page apps
                var currentPage = Application.Current?.Windows[0]?.Page;
                if (currentPage != null)
                {
                    var resposta = await currentPage.DisplayAlert("Alerta", "Confirmar exclusão?", "Sim", "Não");

                    if (resposta)
                    {
                        await contatoRepository.DeleteContato(ContatoAtual);
                        await Refresh(contatoRepository);
                    }
                }
            });

            DisplayCommand = new Command(async () =>
            {
                await contatoRepository.InitializeAsync();
                await Refresh(contatoRepository);
            });
        }

        private async Task Refresh(IAgendaService contatoRepository)
        {
            Contatos = await contatoRepository.GetContatos();
        }
    }
}
