using System;
using Windows.UI.Xaml.Data;

namespace SoftwareKobo.BingWallpaper.Converters
{
    public class AreaToFlagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string area = (string)value;
            switch (area)
            {
                case "de-DE":
                    return "/Assets/germany.png";
                case "en-AU":
                    return "/Assets/australia.png";
                case "en-CA":
                    return "/Assets/canada.png";
                case "en-NZ":
                    return "/Assets/newzealand.png";
                case "en-UK":
                    return "/Assets/england.png";
                case "en-US":
                    return "/Assets/america.png";
                case "ja-JP":
                    return "/Assets/japan.png";
                case "zh-CN":
                    return "/Assets/china.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}