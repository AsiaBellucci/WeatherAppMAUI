namespace WeatherApp;

public partial class MainPage : ContentPage
{
	WeatherService weatherService;

    public MainPage()
	{
		InitializeComponent();
		weatherService = new WeatherService();
	}

	private async void OnGetWeatherClicked(object sender, EventArgs e)
	{

		WeatherData response = await weatherService.GetWeather(cityEntry.Text);
		BindingContext = response;
	}
}

