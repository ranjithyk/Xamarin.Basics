using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Converts boolean to provided Image source
    /// </summary>
    public class BoolToImageConverter : IValueConverter
    {
        /// <summary>
        /// Positive image
        /// </summary>
        public FileImageSource PositiveImageSource { get; set; }

        /// <summary>
        /// Nagative image
        /// </summary>
        public FileImageSource NegativeImageSource { get; set; }

        /// <summary>
        /// Converts boolean to provided Image source
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((bool)value)
                {
                    return PositiveImageSource;
                }
                else
                {

                    return NegativeImageSource;
                }
            }
            else
            {
                return NegativeImageSource;
            }
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
            return value;
        }
    }
}
