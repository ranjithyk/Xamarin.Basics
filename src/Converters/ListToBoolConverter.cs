using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Return true if collection count is > 0 else returns false 
    /// </summary>
    public class ListToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Return true if collection count is > 0 else returns false 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as ICollection;
            if (list != null  && list.Count > 0)
                return true;

            return false;
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
            return !(bool)value;
        }
    }
}
