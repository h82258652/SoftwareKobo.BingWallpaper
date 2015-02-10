using System;
using System.Windows.Data;

namespace SoftwareKobo.BingWallpaper.WPF.Converters
{
    public class HotspotLocationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int hotspotLocation = (int)values[0];
            double grdWidthOrHeight = (double)values[1];
            if (double.IsNaN(grdWidthOrHeight) || grdWidthOrHeight == 0.0d)
            {
                return 0.0d;
            }
            return grdWidthOrHeight * hotspotLocation / 100.0d;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}