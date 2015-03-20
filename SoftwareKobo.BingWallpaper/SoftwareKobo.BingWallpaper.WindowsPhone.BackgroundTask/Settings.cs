using SoftwareKobo.BingWallpaper.Services;
using System.Globalization;
using System.Linq;
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
                    string currentCulture = CultureInfo.CurrentCulture.Name;
                    if (ServiceArea.ListAllSupportAreas.Contains(currentCulture))
                    {
                        return currentCulture;
                    }
                    else
                    {
                        return ServiceArea.GetDefault();
                    }
                }
            }
        }
    }
}