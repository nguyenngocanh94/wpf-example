using System;
using System.Windows.Input;

namespace ViewModel
{
    class Command : ICommand
    {
        private Action commandAction;
        public event EventHandler CanExecuteChanged;

        public Command(Action commandAction)
        {
            this.commandAction = commandAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.commandAction();
        }
    }
}
