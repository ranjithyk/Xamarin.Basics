
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Return tru if object is null else false
    /// </summary>
    public class NullableObjectToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Convert 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return true if object is not null else return false
            return value != null;
        }

        /// <summary>
        /// ConvertBack
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return true if object is not null else return false
            return value != null;
        }
    }
}
