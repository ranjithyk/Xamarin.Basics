using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Convert base64 string image source
    /// </summary>
    public class Base64ToImageSourceConverter : IValueConverter
    {
        /// <summary>
        /// Placeholder image
        /// </summary>
        public FileImageSource PlaholderImageSource { get; set; }

        /// <summary>
        /// Convert base64 string image source
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
                var imageString = (string)value;
                if (!string.IsNullOrEmpty(imageString))
                    return ImageSource.FromStream(() => new MemoryStream(System.Convert.FromBase64String(imageString)));
            }

            return PlaholderImageSource;
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