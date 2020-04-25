using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Basics.Converters
{
    /// <summary>
    /// Converts boolean to provided colors
    /// </summary>
    public class BoolToColorConverter : IValueConverter
    {
        /// <summary>
        /// Positive color
        /// </summary>
        public Color ColorPositive { get; set; } = Color.White;

        /// <summary>
        /// Nagative color
        /// </summary>
        public Color ColorNegative { get; set; } = Color.Black;

        /// <summary>
        /// Converts boolean to provided colors
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
                    return ColorPositive;
                }
                else
                {
                    return ColorNegative;
                }
            }
            else
            {
                return ColorNegative;
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
