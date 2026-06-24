using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfFramework.Controls.Converters
{
    /// <summary>
    /// 데시멀을 문자열로
    /// </summary>
    public class DecimalToStringConverter : IValueConverter
    {
        public DecimalToStringConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is decimal decimalValue)
            {
                if(decimalValue == 0)
                {
                    return string.Empty;
                }
                else
                {
                    return decimalValue.ToString("n0");
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string stringValue
                && decimal.TryParse(stringValue, out decimal decimalValue))
            {
                return decimalValue;
            }
            return double.NaN;
        }
    }
}
