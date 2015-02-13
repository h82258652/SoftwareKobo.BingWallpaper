using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public static class PhoneAccentColorHelper
    {
        public static Color GetPhoneAccentColor()
        {
            var brush = (SolidColorBrush)Application.Current.Resources["PhoneAccentBrush"];
            return brush.Color;
        }
    }
}