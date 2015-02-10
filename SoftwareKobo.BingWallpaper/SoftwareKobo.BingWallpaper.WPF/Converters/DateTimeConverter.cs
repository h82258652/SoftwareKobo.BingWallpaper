using System.Globalization;
using SoftwareKobo.BingWallpaper.Services.Helpers;
using System;
using System.Windows.Data;

namespace SoftwareKobo.BingWallpaper.WPF.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            DateTime dateTime = DateTimeHelper.Parse((string)value);
            return dateTime.ToString("D");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}