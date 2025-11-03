using MauiSQLite.MVVM.Views;
using MauiSQLite.Services;

namespace MauiSQLite
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var serviceProvider = IPlatformApplication.Current?.Services;
            var agendaService = serviceProvider?.GetRequiredService<IAgendaService>();
            return new Window(new NavigationPage(new AgendaView(agendaService!)));
        }
    }
}