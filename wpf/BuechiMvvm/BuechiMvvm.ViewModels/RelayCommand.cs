using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuechiMvvm.ViewModels
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> executeAction;

        public RelayCommand(Action<object> executeAction)
        {
            this.executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }
    }
}
