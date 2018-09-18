using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    class WeatherAPI
    {
        public const string API_KEY = "Azezfvon8T1ftXVBHg395cQUg4UtujLQ";
        public const string BASE_URL = "http://dataservice.accuweather.com/locations/v1/cities/neighbors{0}/?apikey=%09{1}Q";

        public async Task<Weather> GetWeatherInformationAsync(string cityName)
        {
            Weather result = new Weather();

            string url = String.Format(BASE_URL, cityName, API_KEY);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<Weather>(json);
            }

            return result;
        }
    }
}
