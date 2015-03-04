using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace SoftwareKobo.BingWallpaper.Converters
{
    public class ThumbUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string urlBase = (string)value;
            return string.Format(CultureInfo.InvariantCulture, "http://www.bing.com{0}_150x150.jpg", urlBase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}