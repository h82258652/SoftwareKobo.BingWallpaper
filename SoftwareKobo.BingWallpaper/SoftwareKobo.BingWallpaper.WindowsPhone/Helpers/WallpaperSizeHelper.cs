using SoftwareKobo.BingWallpaper.Services;
using System;
using System.Globalization;
using Windows.Foundation;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public static class WallpaperSizeHelper
    {
        public static WallpaperSize GetDefaultSize()
        {
            Size size = DisplayInformationHelper.GetSize();
            double width = size.Width;
            double height = size.Height;

            WallpaperSize wallpaperSize;
            if (Enum.TryParse(string.Format(CultureInfo.InvariantCulture, "_{0}x{1}", width, height), out wallpaperSize))
            {
                return wallpaperSize;
            }
            else
            {
                return WallpaperSize._480x800;
            }
        }
    }
}