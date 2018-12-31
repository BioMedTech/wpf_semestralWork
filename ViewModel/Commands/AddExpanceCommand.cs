using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expence_Tracker.ViewModel
{
    public class AddExpanceCommand : ICommand
    {
        public ExpenseTrackerVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public AddExpanceCommand(ExpenseTrackerVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //VM.GetWeather();
        }
    }
}
