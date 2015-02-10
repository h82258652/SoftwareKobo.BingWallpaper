using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Converter
{
    public class WallpaperSizeNameConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value==null)
            {
                return null;
            }
            WallpaperSize wallpaperSize = (WallpaperSize) value;
            string name = wallpaperSize.GetName();
            if (wallpaperSize==WallpaperSizeHelper.GetDefaultSize())
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
