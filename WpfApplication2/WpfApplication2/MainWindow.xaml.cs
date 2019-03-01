using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
    }

    public class convertRGB : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var red = System.Convert.ToInt32(values[0]);
            var green = System.Convert.ToInt32(values[1]);
            var blue = System.Convert.ToInt32(values[2]);
            
            Color color = Color.FromRgb((byte)red,(byte)green,(byte)blue);
            return color.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}