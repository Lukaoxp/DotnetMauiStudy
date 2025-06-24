using MVVM_Demo.Mvvm.ViewModels;

namespace MVVM_Demo.Mvvm.Views;

public partial class CommandsView : ContentPage
{
    public CommandsView()
    {
        InitializeComponent();
        BindingContext = new CommandViewModel();
    }
}