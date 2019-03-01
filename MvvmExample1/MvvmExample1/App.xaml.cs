using System;
using System.Windows;

namespace MvvmExample1
{
	public partial class App : Application
	{
		[STAThread]
		public static void Main()
		{
			App app = new App();
			app.InitializeComponent();
			app.Run();
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			var viewModel = new MainWindowViewModel();

			// you can do something with the view model in here.

			var window = new MainWindow();
			window.DataContext = viewModel;
			window.ShowDialog();
		}
	}
}
