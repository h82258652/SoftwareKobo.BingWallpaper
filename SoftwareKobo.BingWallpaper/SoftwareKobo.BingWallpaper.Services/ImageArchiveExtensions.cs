using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftwareKobo.BingWallpaper.Services
{
    public static class ImageArchiveExtensions
    {
        public static DateTime GetStartDate(this ImageArchive imageArchive)
        {
            return DateTimeHelper.Parse(imageArchive.StartDate);
        }

        public static DateTime GetFullStartDate(this ImageArchive imageArchive)
        {
            return DateTimeHelper.Parse(imageArchive.FullStartDate);
        }

        public static DateTime GetEndDate(this ImageArchive imageArchive)
        {
            return DateTimeHelper.Parse(imageArchive.EndDate);
        }

        public static string GetUrlWithSize(this ImageArchive imageArchive, WallpaperSize size)
        {
            if (imageArchive==null)
            {
                return null;
            }
            return string.Format("http://www.bing.com{0}_{1}.jpg", imageArchive.UrlBase, size.GetName());
        }
    }
}
