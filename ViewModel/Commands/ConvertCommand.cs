using Expence_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expence_Tracker.ViewModel.Commands
{
    public class ConvertCommand : ICommand
    {
        public CurrencyVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public ConvertCommand(CurrencyVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            var tx = parameter as Transaction;

            //if (tx == null)
            //    return false;
            //if (string.IsNullOrEmpty(tx.From))
            //    return false;
            //if (string.IsNullOrEmpty(tx.To))
            //    return false;
            //if (string.IsNullOrEmpty(tx.Amount))
            //    return false;
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Convert();
        }
    }
}
