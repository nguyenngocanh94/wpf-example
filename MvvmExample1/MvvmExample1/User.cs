
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmExample1
{
	public class User : BindableBase
	{
		private string name;
		public string Name
		{
			get => this.name;
			set
			{
				if (this.name != value)
				{
					this.name = value;

					// if you want to specify name, you can use "nameof".
					// the compiler will automatically change nameof(member-name) to "member-name".
					this.NotifyPropertyChanged(nameof(Name));
				}
			}
		}
	}
}
