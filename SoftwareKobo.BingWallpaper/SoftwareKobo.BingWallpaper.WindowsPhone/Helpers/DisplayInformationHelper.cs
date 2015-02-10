﻿using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.Xaml;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public static class DisplayInformationHelper
    {
        public static Size GetSize()
        {
            return new Size(GetWidth(), GetHeight());
        }

        public static double GetWidth()
        {
            Rect bounds = Window.Current.Bounds;
            double width = bounds.Width;
            return Scale(width);
        }

        public static double GetHeight()
        {
            Rect bounds = Window.Current.Bounds;
            double height = bounds.Height;
            return Scale(height);
        }

        private static double Scale(double value)
        {
            var info = DisplayInformation.GetForCurrentView();
            return value * info.RawPixelsPerViewPixel;
        }
    }
}