using System.Windows;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : Window
    {
        public ItemControl()
        {
            InitializeComponent();
            var view = new ViewModel();
            this.DataContext = view;
        }
    }
}
