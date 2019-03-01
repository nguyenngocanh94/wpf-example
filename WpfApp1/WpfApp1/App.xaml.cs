﻿using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var itemControlWindow = new MainWindow();
            //var itemControlWindow = new ListView();
            itemControlWindow.ShowDialog();
        }
    }
}
