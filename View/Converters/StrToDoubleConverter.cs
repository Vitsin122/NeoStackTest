using System;
using System.Globalization;
using System.Windows.Data;

namespace TestFeatures.View.Converters
{
    /// <summary>
    /// Class of converter string to double and vice versa
    /// </summary>
    class StrToDoubleConverter : IValueConverter
    {
        /// <summary>
        /// Converts double to string. Used in the Converter parameter when defining a binding in XAML code.
        /// </summary>
        /// <param name="value">Converted value</param>
        /// <param name="targetType">Required Type</param>
        /// <param name="parameter"></param>
        /// <param name="culture">Detailed info of the conversion object</param>
        /// <returns>Returns a string converted from double. If the double is invalid, then an empty string is returned.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
                return value.ToString();
            else
                return " ";
        }
        /// <summary>
        /// Converts string to double. Used in the Converter parameter when defining a binding in XAML code.
        /// </summary>
        /// <param name="value">Converted value</param>
        /// <param name="targetType">Required type</param>
        /// <param name="parameter"></param>
        /// <param name="culture">Detailed info of the conversion object</param>
        /// <returns>Returns a double converted from string. If the string is invalid, then 0 is returned.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out double result))
                return result;
            else
                return 0;
        }
    }
}
