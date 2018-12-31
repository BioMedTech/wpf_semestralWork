using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expence_Tracker.ViewModel.Commands;

namespace Expence_Tracker.ViewModel
{
    public class CurrencyVM
    {
        public ObservableCollection<string> Currencies { get; set; }

        public async void getCurrencies()
        {
            ObservableCollection<string> currencies = new ObservableCollection<string>();
            var curr= await AutocompleteAPI.GetCurrencyInformationAsync();
            foreach (var c in curr)
            {
                currencies.Add(c.Key+" - "+c.Value);
            }
        }
        
        public CurrencyVM()
        {
            Currencies = new ObservableCollection<string>();
            getCurrencies();
        }

     
    }
}
