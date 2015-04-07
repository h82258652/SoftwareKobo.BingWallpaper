using SoftwareKobo.BingWallpaper.Helpers;
using System;
using Windows.UI.Xaml.Data;

namespace SoftwareKobo.BingWallpaper.Converters
{
    public class AreaToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string area = (string)value;
            string name = null;
            switch (area)
            {
                case "de-DE":
                    name = ResourcesHelper.Germany;
                    break;
                case "en-AU":
                    name = ResourcesHelper.Australia;
                    break;
                case "en-CA":
                    name = ResourcesHelper.Canada;
                    break;
                case "en-NZ":
                    name = ResourcesHelper.NewZealand;
                    break;
                case "en-UK":
                    name = ResourcesHelper.England;
                    break;
                case "en-US":
                    name = ResourcesHelper.America;
                    break;
                case "ja-JP":
                    name = ResourcesHelper.Japan;
                    break;
                case "zh-CN":
                    name = ResourcesHelper.China;
                    break;
            }
            return string.Format("{0}({1})", name, area);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}