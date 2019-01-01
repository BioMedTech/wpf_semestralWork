using Expence_Tracker.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expence_Tracker.ViewModel
{
    public class AutocompleteAPI
    {
        private const string API_KEY = "a3da661fa771f08669434e3ef61b4dba";
        private const string BASE_URL = "http://data.fixer.io/api/{0}?access_key={1}";
        private const string BASE_CONV_URL = "http://free.currencyconverterapi.com/api/v6/convert/?q={0}_{1}&compact=ultra";


        public static async Task<Dictionary<string, string>> GetAllCurrencyAsync()
        {
            Dictionary<string, string> currencies;
            CurrencyList result = new CurrencyList();

            string url = string.Format(BASE_URL, "symbols", API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<CurrencyList>(json);
                currencies = result.symbols;

            }

            return currencies;
        }

        public static async Task<Dictionary<string, string>> ConvertCurrency(Transaction transaction)
        {
            string url = string.Format(BASE_CONV_URL, transaction.From, transaction.To);
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            return result;

        }
    }
}
