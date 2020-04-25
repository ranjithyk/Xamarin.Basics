namespace Xamarin.Basics.Helpers
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class ResourceHelper
    {
        /// <summary>
        /// Returns Resource value object.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetResourceValue(string keyName)
        {
            if (Forms.Application.Current.Resources.TryGetValue(keyName, out var retVal))
                return retVal;
            else return null;
        }
    }
}
