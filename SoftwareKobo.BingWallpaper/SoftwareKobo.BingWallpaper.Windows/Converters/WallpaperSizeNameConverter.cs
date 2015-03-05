using SoftwareKobo.BingWallpaper.Helpers;
using SoftwareKobo.BingWallpaper.Services;
using System;
using Windows.UI.Xaml.Data;

namespace SoftwareKobo.BingWallpaper.Converters
{
    public class WallpaperSizeNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            WallpaperSize wallpaperSize = (WallpaperSize)value;
            string name = wallpaperSize.GetName();
            if (wallpaperSize == WallpaperSizeHelper.GetDefaultSize())
            {
                name = name + ResourcesHelper.Default;
            }
            return name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}