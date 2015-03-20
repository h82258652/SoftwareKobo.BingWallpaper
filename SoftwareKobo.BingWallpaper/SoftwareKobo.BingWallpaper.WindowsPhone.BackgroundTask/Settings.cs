using System.Globalization;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace SoftwareKobo.BingWallpaper.BackgroundTask
{
    public static class Settings
    {
        internal static string Area
        {
            get
            {
                IPropertySet roamingSettings = ApplicationData.Current.RoamingSettings.Values;
                if (roamingSettings.ContainsKey("Area"))
                {
                    return (string)roamingSettings["Area"];
                }
                else
                {
                    return CultureInfo.CurrentCulture.Name;
                }
            }
        }
    }
}