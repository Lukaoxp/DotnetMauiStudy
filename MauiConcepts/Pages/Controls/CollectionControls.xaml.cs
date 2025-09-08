using MauiConcepts.Models;

namespace MauiConcepts.Pages.Controls;

public partial class CollectionControls : ContentPage
{
    public CollectionControls()
    {
        InitializeComponent();
        BindingContext = new FotoViewModel();
    }
}