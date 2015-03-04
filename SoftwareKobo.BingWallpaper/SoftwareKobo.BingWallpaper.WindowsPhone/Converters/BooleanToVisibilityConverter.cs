using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SoftwareKobo.BingWallpaper.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b = (bool)value;
            return b ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = (Visibility) value;
            return visibility == Visibility.Visible ? true : false;
        }
    }
}