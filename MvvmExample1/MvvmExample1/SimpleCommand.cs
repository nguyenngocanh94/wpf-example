using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmExample1
{
	public class SimpleCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private Action commandAction;

		public SimpleCommand(Action commandAction)
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
