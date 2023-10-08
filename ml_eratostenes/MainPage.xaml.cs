using Microsoft.Maui.ApplicationModel;
using System.Drawing;

namespace ml_eratostenes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
           InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(count.Text))
            {
                await DisplayAlert("Błąd", "Wprowadź dane", "OK");
                return;
            }
            int max = int.Parse(count.Text);
            if (max < 2)
            {
                await DisplayAlert("Błąd", "Wprowadź liczbe większą lub równą 10", "OK");
                return;
            }
            btnn.Text = "Ładowanie...";
            bool[] isPrime = new bool[max + 1];
            await Task.Run(() =>
            {
                for (int i = 2; i <= max; i++)
                {
                    isPrime[i] = true;
                }

                for (int p = 2; p * p <= max; p++)
                {
                    if (isPrime[p])
                    {
                        for (int i = p * p; i <= max; i += p)
                        {
                            isPrime[i] = false;
                        }
                    }
                }
            });
            await Navigation.PushAsync(new Eratostenes(max, isPrime));
            btnn.Text = "Generuj";

        }
    }
}