using SimpleIoC;
using System.Windows;
using ViewModel.Command;

namespace Mics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {           
            DIContainer.Register<IDialogOpenner, OpenFileDialogCommand>();
            new Audio().ShowDialog();
        }
    }
}
