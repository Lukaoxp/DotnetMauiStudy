using System.Globalization;

namespace MauiConcepts.Pages.Controls;

public partial class ValueDefiningControls : ContentPage
{
    public ValueDefiningControls()
    {
        InitializeComponent();
    }

    private async void Checkbox1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
            await DisplayAlert("Checkbox", "Marcado", "OK");
        else
            await DisplayAlert("Checkbox", "Desmarcado", "OK");
    }

    private async void Checkbox2_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
            await DisplayAlert("Checkbox", "Marcado", "OK");
        else
            await DisplayAlert("Checkbox", "Desmarcado", "OK");
    }

    private async void Checkbox3_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
            await DisplayAlert("Checkbox", "Marcado", "OK");
        else
            await DisplayAlert("Checkbox", "Desmarcado", "OK");
    }

    private void Slider1_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblSlider.Text = e.NewValue.ToString();
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblStepper.Text = e.NewValue.ToString();
    }

    private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        CultureInfo culture = new CultureInfo("pt-BR");
        var data = ((DatePicker)sender).Date;
        var dataSelecionada = data.ToString("d", culture);
        await DisplayAlert("Data selecionada", dataSelecionada, "Ok");
    }
}