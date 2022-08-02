using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    public class WeatherService
    {
        HttpClient client;

        public WeatherService()
        {
            client = new HttpClient();
        }

        public async Task<WeatherData> GetWeather(string city)
        {
            string url = $"{Constants.OpenWeatherMapEndpoint}";
            url += $"?q={city}&units=metric&APPID={Constants.OpenWeatherMapAPIKey}";
            WeatherData data = new WeatherData();
            try
            {
                var response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return data;
        }
    }
}
