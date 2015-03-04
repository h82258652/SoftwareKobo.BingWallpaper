using SoftwareKobo.BingWallpaper.Services;
using System;
using System.Globalization;
using System.Windows;

namespace SoftwareKobo.BingWallpaper.Helpers
{
    public static class WallpaperSizeHelper
    {
        public static WallpaperSize GetDefaultsSize()
        {
            double width = SystemParameters.PrimaryScreenWidth;
            double height = SystemParameters.PrimaryScreenHeight;
            WallpaperSize wallpaperSize;
            if (Enum.TryParse(string.Format(CultureInfo.InvariantCulture, "_{0}x{1}", width, height), out wallpaperSize))
            {
                return wallpaperSize;
            }
            else
            {
                return WallpaperSize._1024x768;
            }
        }
    }
}