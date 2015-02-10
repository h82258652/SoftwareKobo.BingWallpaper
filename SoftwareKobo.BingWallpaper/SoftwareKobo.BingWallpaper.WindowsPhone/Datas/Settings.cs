using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;
using System;
using Windows.Storage;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Datas
{
    public static class Settings
    {
        public static WallpaperSize WallpaperSize
        {
            get
            {
                var localSettings = ApplicationData.Current.LocalSettings.Values;
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
                var localSettings = ApplicationData.Current.LocalSettings.Values;
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
                var roamingSettings = ApplicationData.Current.RoamingSettings.Values;
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
                var roamingSettings = ApplicationData.Current.RoamingSettings.Values;
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