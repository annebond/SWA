using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Example7.ViewModel.Blueprints;

namespace Example7.Converter
{
    class ObjectToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                ContructionDetails temp = (ContructionDetails) value;
                DateTime comptime = DateTime.ParseExact(temp.CompletionTime, "hh:mm", CultureInfo.InvariantCulture);
                DateTime time = DateTime.ParseExact(temp.Time, "hh:mm", CultureInfo.InvariantCulture);
                if ((comptime - time).Minutes <= 2) return new SolidColorBrush(Colors.Red);
                if ((comptime - time).Minutes <= 2) return new SolidColorBrush(Colors.Yellow);
                return new SolidColorBrush(Colors.Green);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
