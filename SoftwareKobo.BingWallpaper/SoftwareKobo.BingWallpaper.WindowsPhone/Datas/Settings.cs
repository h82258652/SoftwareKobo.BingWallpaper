using Windows.Foundation.Collections;
using SoftwareKobo.BingWallpaper.Helpers;
using SoftwareKobo.BingWallpaper.Services;
using System;
using Windows.Storage;

namespace SoftwareKobo.BingWallpaper.Datas
{
    public static class Settings
    {
        public static WallpaperSize WallpaperSize
        {
            get
            {
                IPropertySet localSettings = ApplicationData.Current.LocalSettings.Values;
                WallpaperSize wallpaperSize;
                if (localSettings.ContainsKey("WallpaperSize"))
                {
                    if (Enum.TryParse((string)localSettings["WallpaperSize"], out wallpaperSize))
                    {
                        return wallpaperSize;
                    }
                }
                wallpaperSize = WallpaperSizeHelper.GetDefaultSize();
                return wallpaperSize;
            }
            set
            {
                IPropertySet localSettings = ApplicationData.Current.LocalSettings.Values;
                if (localSettings.ContainsKey("WallpaperSize"))
                {
                    localSettings["WallpaperSize"] = value.ToString();
                }
                else
                {
                    localSettings.Add("WallpaperSize", value.ToString());
                }
            }
        }

        public static string SaveLocation
        {
            get
            {
                IPropertySet roamingSettings = ApplicationData.Current.RoamingSettings.Values;
                if (roamingSettings.ContainsKey("SaveLocation"))
                {
                    return (string)roamingSettings["SaveLocation"];
                }
                else
                {
                    return ResourcesHelper.PictureLibrary;
                }
            }
            set
            {
                IPropertySet roamingSettings = ApplicationData.Current.RoamingSettings.Values;
                if (roamingSettings.ContainsKey("SaveLocation"))
                {
                    roamingSettings["SaveLocation"] = value;
                }
                else
                {
                    roamingSettings.Add("SaveLocation", value);
                }
            }
        }
    }
}