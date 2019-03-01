using System.ComponentModel;


namespace WpfApp1
{
    class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            // "?" before the method "Invoke" means, "call the method if the event PropertyChanged is not null".
            // "?" is very convenient operator.
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
