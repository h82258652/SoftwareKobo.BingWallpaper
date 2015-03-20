using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using System;
using Windows.UI.Xaml.Data;

namespace SoftwareKobo.BingWallpaper.Converters
{
    public class WallpaperCopyrightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ImageArchive imageArchive = (ImageArchive)value;
            return imageArchive.GetCopyright();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}