using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restourant.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canexecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object? parameter)
        {
            return canexecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
