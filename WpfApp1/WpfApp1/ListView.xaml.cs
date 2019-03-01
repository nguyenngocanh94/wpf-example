using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : Window
    {
        public ListView()
        {
            InitializeComponent();
            var todoList = new List<Task>();
            todoList.Add(new Task()
            { Name = "LEARN WPF", Decription = "'WpfApp1.exe' (CLR v4.0.30319: WpfApp1.exe): Loaded udio.DesignTools.WpfTap.dll'. Skipped loading symbols. Module is optimiz", Priority = 1, Type = TaskType.Work, CompletePercent = 75 });
            todoList.Add(new Task() { Name = "LEARN Winform", Decription = "'WpfApp1.exe' (CLR v4.0.30319: WpfApp1.exe): Loaded gnostics.325icrosoft.VisualStudio.DesignTools.WpfTap.dll'. Skipped loading symbols. Module is optimiz", Priority = 4, Type = TaskType.Home, CompletePercent = 20 });
            lvUsers.ItemsSource = todoList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(todoList);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Type");
            view.GroupDescriptions.Add(groupDescription);
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Task).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }
    }
}
