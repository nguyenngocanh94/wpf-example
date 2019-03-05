using System.Windows;
using ViewModel;
namespace Mics
{
    /// <summary>
    /// Interaction logic for Audio.xaml
    /// </summary>
    public partial class Audio : Window
    {
        public MicsViewModel viewModel;

        public Audio()
        {
            InitializeComponent();
            viewModel = new MicsViewModel();
            DataContext = viewModel;
        }
    }
}
