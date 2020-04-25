using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Append Image directory
    /// </summary>
    public class RelativeImageSourceConverter : IValueConverter
    {
        /// <summary>
        /// Relartive Image Directory
        /// </summary>
        public string ImageDirectory { get; set; }

        /// <summary>
        /// Append Image directory and return path
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == Device.UWP && !string.IsNullOrEmpty(ImageDirectory))
                return $"{ImageDirectory}/{value}";
            else
                return value;
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
