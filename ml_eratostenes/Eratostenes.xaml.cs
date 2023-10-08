namespace ml_eratostenes;

public partial class Eratostenes : ContentPage
{
	public Eratostenes(int max, bool[] isPrime)
	{
        InitializeComponent();
        int hmax = (max - (max % 10)) / 10+1;
        
        // Przedstawienie w formie "tabeli"
        for (int i = 0; i < 10; i++)
        {
            gridd.AddColumnDefinition(new ColumnDefinition());
        }
        for (int i = 0; i < hmax; i++)
        {
            gridd.AddRowDefinition(new RowDefinition(HeightRequest = 40));
            for (int j = 1; j < 11; j++)
            {
                int n = (i * 10 + j);
                if (n > max)
                    return;
                Frame f = new Frame() { BorderColor = Colors.Black, Padding = 0.5, CornerRadius = 0 };
                Label l = new Label() { Text = n.ToString(), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };

                if (isPrime[n])
                    l.Background = Colors.Green;
                else
                    l.Background = Colors.LightBlue;
                f.Content = l;

                Grid.SetColumn(f, j - 1);
                Grid.SetRow(f, i);
                gridd.Children.Add(f);
            }
        }
    }
}