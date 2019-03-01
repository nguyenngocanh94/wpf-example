using System;
using System.Windows.Input;

namespace ModelView
{
    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> canExecute;
    
        private readonly Action<T> execute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute ?? throw new ArgumentNullException("missing action");
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);
        }

       
    }
}
