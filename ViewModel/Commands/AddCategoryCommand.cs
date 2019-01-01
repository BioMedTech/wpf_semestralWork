using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expence_Tracker.ViewModel.Commands
{
    public class AddCategoryCommand : ICommand
    {
        public ExpenseTrackerVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public AddCategoryCommand(ExpenseTrackerVM vm)
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
