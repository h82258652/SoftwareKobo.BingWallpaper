using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareKobo.BingWallpaper.Services
{
    public static class WallpaperSizeExtensions
    {
        public static string GetName(this WallpaperSize size)
        {
            return size.ToString().TrimStart('_');
        }
    }
}
