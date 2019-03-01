using System.Windows;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Diaglog.xaml
    /// </summary>
    public partial class Diaglog : Window
    {
        public Diaglog()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

         public object GetTask()
         {
            return new Task()
            {
                Name = taskName.Text,
                CompletePercent = System.Convert.ToInt32(completePercent.Value),
                Priority = System.Convert.ToInt32(piority.Value)
            };
         }
    }
}
