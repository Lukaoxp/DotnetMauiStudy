using MauiCollectionView.MVVM.ViewModels;

namespace MauiCollectionView.MVVM.Views;

public partial class LayoutView : ContentPage
{
    public LayoutView()
    {
        InitializeComponent();
        BindingContext = new ProdutoViewModel();
    }
}