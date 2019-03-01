using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmExample1
{
    public class MainWindowViewModel : BindableBase
    {
		private ObservableCollection<User> users;
		public ObservableCollection<User> Users
		{
			get => this.users;
			set
			{
				this.users = value;
				this.NotifyPropertyChanged(nameof(Users));
			}
		}

		private User selectedUser;
		public User SelectedUser
		{
			get => this.selectedUser;
			set
			{
				this.selectedUser = value;
				this.NotifyPropertyChanged(nameof(SelectedUser));
			}
		}

		public ICommand AddUserCommand { get; set; }
		public ICommand ChangeUserCommand { get; set; }
		public ICommand DeleteUserCommand { get; set; }

		public MainWindowViewModel()
		{
			this.Users = new ObservableCollection<User>();

			this.Users.Add(new User()
			{
				Name = "John Doe"
			});

			this.Users.Add(new User()
			{
				Name = "Jane Doe"
			});

			this.AddUserCommand = new SimpleCommand(() => this.Users.Add(new User()
			{
				Name = "New user"
			}));

			this.ChangeUserCommand = new SimpleCommand(() =>
			{
				if (this.SelectedUser != null)
				{
					this.SelectedUser.Name = "Random Name";
				}
			});

			this.DeleteUserCommand = new SimpleCommand(() =>
			{
				if (this.SelectedUser != null)
				{
					this.Users.Remove(this.SelectedUser);
					this.SelectedUser = null;
				}
			});
		}
	}
}
