using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expence_Tracker.ViewModel
{
    public class GeocodingAPI
    {
        public const string API_ID = "dgoJ1B06KIVchlBZyuTb";
        public const string API_KEY = "zjnuIVHZIbuNDov6owIn~aFra-ZF086kr0EaRmCbO2Q~Ap54C50CrDGSNmD53S8rdjMHWuNosLeSjnvS7WYZ5FHQmCqW7_cZa2dWCF8kRooD";
        public const string API_CODE = "kA-4Yf7-_BthV_SY7U6QYg";
        public const string BASE_URL = "https://1.base.maps.api.here.com/maptile/2.1/maptile/newest/normal.day/13/4400/2686/256/png8?app_id={0}&app_code={1}";
        public const string BASE_URL_AUTOCOMPLETE = "http://autocomplete.wunderground.com/aq?query={0}";

        //public static async Task<Web> GetWeatherInformationAsync(string link)
        //{
        //    WeatherUnderground result = new WeatherUnderground();

        //    string url = string.Format(BASE_URL, API_ID, API_CODE);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        var response = await client.GetAsync(url);
        //        string json = await response.Content.ReadAsStringAsync();

        //        result = JsonConvert.DeserializeObject<WeatherUnderground>(json);
        //    }

        //    return result;
        //}

        //public static async Task<List<RESULT>> GetAutocompleteAsync(string query)
        //{
        //    List<RESULT> cities = new List<RESULT>();

        //    string url = string.Format(BASE_URL_AUTOCOMPLETE, query);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        var response = await client.GetAsync(url);
        //        string json = await response.Content.ReadAsStringAsync();

        //        var city = JsonConvert.DeserializeObject<City>(json);
        //        cities = city.RESULTS;
        //    }

        //    return cities;
        //}
    }
}
