using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XmlnsDefinition("http://xamarin.com/schemas/2014/forms", "Xamarin.Forms")]
namespace Xamarin.Basics.MarkupExtensions
{
    [ContentProperty(nameof(Path))]
    public class ImageSourceExtension : IMarkupExtension<FileImageSource>
    {
        static string imageDirectory;

        public string Path { get; set; }

        public FileImageSource ProvideValue(IServiceProvider serviceProvider) => Convert(Path);

        /// <summary>
        /// Finds the image in provided directory and return image source
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileImageSource Convert(string path)
        {
            if (path == null) throw new InvalidOperationException($"Cannot convert null to {typeof(ImageSource)}");

            if (Device.RuntimePlatform == Device.UWP && !string.IsNullOrEmpty(imageDirectory))
            {
                path = System.IO.Path.Combine(imageDirectory, path);
            }
            return (FileImageSource)ImageSource.FromFile(path);
        }

        /// <summary>
        /// Set image directory
        /// </summary>
        /// <param name="directory"></param>
        public static void SetImageDirectory(string directory)
        {
            imageDirectory = directory;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
