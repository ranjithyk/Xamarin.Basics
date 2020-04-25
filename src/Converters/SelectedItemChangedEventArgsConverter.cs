using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Return SelectedItem from SelectedItemChangedEventArgs
    /// </summary>
    public class SelectedItemChangedEventArgsConverter : IValueConverter
    {
        /// <summary>
        /// Return SelectedItem from SelectedItemChangedEventArgs
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectedItemChangedEventArgs;
            if(eventArgs == null)
            {
                throw new ArgumentException("Expected SelectedItemChangedEventArgs","value");
            }
            return eventArgs.SelectedItem;
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
            throw new NotImplementedException();
        }
    }
}
