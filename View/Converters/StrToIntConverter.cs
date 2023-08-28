using System;
using System.Globalization;
using System.Windows.Data;

namespace TestFeatures.View.Converters
{

    /// <summary>
    /// Class of converter string to int and vice versa
    /// </summary>
    public class StrToIntConverter : IValueConverter
    {
        /// <summary>
        /// Converts int to string. Used in the Converter parameter when defining a binding in XAML code.
        /// </summary>
        /// <param name="value">Converted value</param>
        /// <param name="targetType">Required Type</param>
        /// <param name="parameter"></param>
        /// <param name="culture">Detailed info of the conversion object</param>
        /// <returns>Returns a string converted from int. If the int is invalid, then an empty string is returned.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
                return value.ToString();
            else
                return " ";
        }
        /// <summary>
        /// Converts string to int. Used in the Converter parameter when defining a binding in XAML code.
        /// </summary>
        /// <param name="value">Converted value</param>
        /// <param name="targetType">Required type</param>
        /// <param name="parameter"></param>
        /// <param name="culture">Detailed info of the conversion object</param>
        /// <returns>Returns a int converted from string. If the string is invalid, then 0 is returned.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse(value?.ToString(), out int result))
                return result;
            else
                return 0;
        }
    }
}
