using System;
namespace Xamarin.Basics.Helpers
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class PlatformCulture
    {
        /// <summary>
        /// The resource Culture needs to be set when the application load based on platform, public Interface ILocalization uses this. 
        /// </summary>
        /// <param name="platformCultureString"></param>
        public PlatformCulture(string platformCultureString)
        {

            if (String.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException("Expected culture identifier", "platformCultureString"); 
            }
            PlatformString = platformCultureString.Replace("_", "-"); 
            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }
        public string PlatformString { get; private set; }
        public string LanguageCode { get; private set; }
        public string LocaleCode { get; private set; }
        public override string ToString()
        {
            return PlatformString;
        }
    }
}
