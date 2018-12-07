using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Sample1.Converter
{
    class BoolToBrushConverter : IValueConverter
    {
        static Brush green = new SolidColorBrush(Colors.Green);
        static Brush orange = new SolidColorBrush(Colors.OrangeRed);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool temp = (bool)value; //casten
            if (temp)
            {
                return green;
            }

            return orange;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
