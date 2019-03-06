using System;
using System.Windows.Input;

namespace ViewModel.Command
{
    class Commander : ICommand
    {
        private Action commandAction;
        public event EventHandler CanExecuteChanged;

        public Commander(Action commandAction)
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
