namespace CodeQuotes2;

public partial class MainPage : ContentPage
{
    List<string> quotes7 = new List<string>();  // Για να αλλάζει το Quote.
    public MainPage()
    {
        InitializeComponent();
    }

    // Για να αλλάζει το Quote.
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMauiAsset();
    }

    async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);  // Read the File.

        // var contents = reader.ReadToEnd(); // Για να βάλω το περιεχόμενο όλο σε μία μεταβλητή.

        while (reader.Peek() != -1)
        {
            quotes7.Add(reader.ReadLine());
        }

    }

    Random random = new Random();  // Για να αλλάζει το Background σε Gradient.

    private void btngenerateQuote_Clicked(object sender, EventArgs e)
    {
        // Για να αλλάζει το Background σε Gradient.
        var startColor = System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        var endColor = System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        var colors = ColorUtility.ColorControls.GetColorGradient(startColor, endColor, 6);  // 6 χρώματα


        float stopOffset = .0f;

        var stops = new GradientStopCollection();

        foreach (var c in colors)
        {
            stops.Add(new GradientStop(Color.FromArgb(c.Name), stopOffset));
            stopOffset += .2f;
        }

        var gradient = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 1));

        background.Background = gradient;


        // Για να αλλάζει το Quote.
        int index = random.Next(quotes7.Count);
        quotesLabel.Text = quotes7[index];                //  x:Name="quotesLabel"

    }

}

