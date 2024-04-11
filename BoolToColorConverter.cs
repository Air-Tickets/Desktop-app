using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Desktop_app
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isRed)
            {
                return isRed ? Brushes.Red : Brushes.White; // Jeśli wartość boolowska jest prawdziwa, zwróć kolor czerwony, w przeciwnym razie biały.
            }

            return Brushes.White; // Domyślnie zwróć biały kolor.
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
