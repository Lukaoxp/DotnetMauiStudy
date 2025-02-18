namespace MauiControls.Pages;

public partial class MauiSetValueControls : ContentPage
{
    public MauiSetValueControls()
    {
        InitializeComponent();
        lblStepper.Text = stepper1.Value.ToString();
    }

    private async void CheckBox1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            await DisplayAlert("CheckBox1", "Checked", "OK");
        }
        else
        {
            await DisplayAlert("CheckBox1", "Unchecked", "OK");
        }
    }

    private async void CheckBox2_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            await DisplayAlert("CheckBox1", "Checked", "OK");
        }
        else
        {
            await DisplayAlert("CheckBox1", "Unchecked", "OK");
        }
    }

    private async void CheckBox3_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            await DisplayAlert("CheckBox1", "Checked", "OK");
        }
        else
        {
            await DisplayAlert("CheckBox1", "Unchecked", "OK");
        }
    }

    private void Slider1_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double valor = Math.Round(e.NewValue, 2);
        lblSlider.Text = valor.ToString();
    }

    private void stepper1_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblStepper.Text = e.NewValue.ToString();
    }

    private async void switch1_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            await DisplayAlert("Switch1", "On", "OK");
        }
    }
}