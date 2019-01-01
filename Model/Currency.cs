using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expence_Tracker.Model
{
    public class Transaction:INotifyPropertyChanged
    {
       
        private string from;
        public string From
        {
            get { return from; }
            set
            {
                from = value;
                OnPropertyChanged("From");
            }
        }
        private string to;
        public string To
        {
            get { return to; }
            set
            {
                to = value;
                OnPropertyChanged("To");
            }
        }
        private string amount;
        public string Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class CurrencyList : INotifyPropertyChanged
    {
       public bool success;
       private Dictionary<string, string> Symbols=new Dictionary<string, string>();
        public Dictionary<string, string> symbols
        {
            get { return Symbols; }
            set
            {
                Symbols = value;
                OnPropertyChanged("symbols");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class Responce : INotifyPropertyChanged
    {
        private Transaction Query;

        public Transaction query
        {
            get { return Query; }
            set
            {
                Query = value;
                OnPropertyChanged("query");
            }
        }

        private string Result;

        public string result
        {
            get { return Result;  }
            set
            {
                Result = value;
                OnPropertyChanged("result");
            }
        }
        private string Date;
        public string date
        {
            get { return Date;}
            set
            {
                Date = value;
                OnPropertyChanged("date");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
