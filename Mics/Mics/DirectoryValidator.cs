using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Mics
{
    class DirectoryValidator : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return false;
            }
            if (Directory.Exists((string)value))
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
