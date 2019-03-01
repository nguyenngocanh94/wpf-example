using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmExample1
{
    public abstract class BindableBase : INotifyPropertyChanged
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
