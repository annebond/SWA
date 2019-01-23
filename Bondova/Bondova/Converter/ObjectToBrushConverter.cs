using Bondova.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Bondova.Converter
{
    class ObjectToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

                //hier kommt eine Logik für abhängig von Anzahl der Container von einem Flugzeug
                string temp = (string) value;
                string s = temp;
                if (s == "F4701") return new SolidColorBrush(Colors.Green);
                if (s == "F4711") return new SolidColorBrush(Colors.Yellow);
                if (s == "F5722") return new SolidColorBrush(Colors.Red);

                
                
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}