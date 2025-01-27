namespace MauiDemo;

public partial class Oraculo : ContentPage
{
    public Oraculo()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var resposta = this.FindByName<VerticalStackLayout>("Resposta");
        resposta.IsVisible = true;
    }
}