using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;

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
                    if (Enum.TryParse((string)localSettings["WallpaperSize"],out wallpaperSize))
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
                    localSettings.Add("WallpaperSize",value.ToString());
                }
            }
        }
    }
}
