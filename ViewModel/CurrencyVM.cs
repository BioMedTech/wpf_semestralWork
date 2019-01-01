using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expence_Tracker.Model;
using Expence_Tracker.ViewModel.Commands;

namespace Expence_Tracker.ViewModel
{
    public class CurrencyVM:INotifyPropertyChanged
    {
        public ObservableCollection<string> Currencies { get; set; }
        public ObservableCollection<string> FullCurrency { get; set; }
        private Transaction transaction;


        public ConvertCommand ConvertCommand { get; set; }

        public Transaction Transaction
        {
            get { return transaction; }
            set
            {
                transaction = value;
                OnPropertyChanged("Transaction");
            }
        }


        private float result;
        public float Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }


        public async void getCurrencies()
        {
            var curr= await AutocompleteAPI.GetAllCurrencyAsync();
            foreach (var c in curr)
            {
                Currencies.Add(c.Key);
                FullCurrency.Add(c.Key + " - " + c.Value);
            }
        }
        public async void Convert()
        {
            var res=await AutocompleteAPI.ConvertCurrency(transaction);
            foreach (var r in res)
            {
                Result = float.Parse(r.Value, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(Transaction.Amount, CultureInfo.InvariantCulture.NumberFormat);
            }
        }
        
        public CurrencyVM()
        {
            Currencies = new ObservableCollection<string>();
            FullCurrency = new ObservableCollection<string>();
            Transaction = new Transaction();
            ConvertCommand = new ConvertCommand(this);
            getCurrencies();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
