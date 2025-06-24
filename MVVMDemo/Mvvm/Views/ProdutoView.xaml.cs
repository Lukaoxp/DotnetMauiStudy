using MVVM_Demo.Mvvm.ViewModels;

namespace MVVM_Demo.Mvvm.Views;

public partial class ProdutoView : ContentPage
{
    public ProdutoView()
    {
        InitializeComponent();

        BindingContext = new ProdutoViewModel();
    }
}