using System;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.System.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace SoftwareKobo.BingWallpaper.Helpers
{
    public static class DisplayInformationHelper
    {
        public static Size GetSize()
        {
            

var xxx=            DisplayInformation.GetForCurrentView();

            Rect bounds = Window.Current.Bounds;
            Size size = new Size(bounds.Width, bounds.Height);
            Debugger.Break();
            return size;
        }

        public static double GetWidth()
        {
            return GetSize().Width;
        }

        public static double GetHeight()
        {
            return GetSize().Height;
        }
    }
}