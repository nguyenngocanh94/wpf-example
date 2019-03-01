using System;
using System.Windows.Input;

namespace WpfApp1
{
    class BasicCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action Doing;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.Doing();
        }

        public BasicCommand(Action action)
        {
            this.Doing = action;
        }
    }
}
