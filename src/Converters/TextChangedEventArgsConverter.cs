using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Returns New value from the TextChangedEventArgs
    /// </summary>
    public class TextChangedEventArgsConverter : IValueConverter
    {
        /// <summary>
        /// Returns New value from the TextChangedEventArgs
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as TextChangedEventArgs;

            if (eventArgs == null)
            {
                throw new ArgumentException("Expected TappedEventArgs", "value");
            }

            return eventArgs.NewTextValue;
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
