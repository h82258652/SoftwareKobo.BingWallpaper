using System;
using System.Globalization;
using Windows.Foundation;
using Windows.UI.Xaml;
using SoftwareKobo.BingWallpaper.Services;
using Windows.Graphics.Display;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public static class WallpaperSizeHelper
    {
        public static WallpaperSize GetDefaultSize()
        {
Rect rect=            Window.Current.Bounds;
            double width= rect.Width;
            double height = rect.Height;
            WallpaperSize wallpaperSize;
            if (Enum.TryParse(string.Format(CultureInfo.InvariantCulture,"_{0}x{1}",width,height),out wallpaperSize))
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