using System;
using System.Globalization;
using System.Windows.Data;

namespace SoftwareKobo.BingWallpaper.Converters
{
    public class ThumbUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string urlBase = (string)value;
            return string.Format(CultureInfo.InvariantCulture, "http://www.bing.com{0}_240x240.jpg", urlBase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}