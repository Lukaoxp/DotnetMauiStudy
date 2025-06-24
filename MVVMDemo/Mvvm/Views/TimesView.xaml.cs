using MVVM_Demo.Mvvm.ViewModels;

namespace MVVM_Demo.Mvvm.Views;

public partial class TimesView : ContentPage
{
    public TimesView()
    {
        InitializeComponent();
        BindingContext = new TimesViewModel();
    }
}