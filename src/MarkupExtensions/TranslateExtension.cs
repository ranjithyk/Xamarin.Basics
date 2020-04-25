using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Basics.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        static CultureInfo ci = CultureInfo.CurrentCulture;
        static Lazy<ResourceManager> resourceManager;

        public string Text { get; set; }

        /// <summary>
        /// Get local language
        /// </summary>
        public TranslateExtension()
        {
        }

        /// <summary>
        /// Inilialize resource manager
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resourceClass"></param>
        public static void InitilizeResource(string resourceId, Type resourceClass)
        {
            resourceManager = new Lazy<ResourceManager>(() => new ResourceManager(resourceId, IntrospectionExtensions.GetTypeInfo(resourceClass).Assembly));
        }

        /// <summary>
        /// Set language culture
        /// </summary>
        /// <param name="cultureInfo"></param>
        public static void SetCulture(CultureInfo cultureInfo)
        {
            ci = cultureInfo;
        }

        /// <summary>
        /// get text for local language
        /// </summary>aoo
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (resourceManager == null)
                throw new InvalidOperationException("Resources has not been Initialized. Inilialize with TranslateExtension.InitilizeResource() method");

            if (Text == null)
                return string.Empty;

            var translation = resourceManager.Value.GetString(Text, ci);
            if (translation == null)
            {
                translation = Text;
            }

            return translation;
        }
    }
}
