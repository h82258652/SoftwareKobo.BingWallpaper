using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Helpers;
using System;
using System.Linq;

namespace SoftwareKobo.BingWallpaper.Services
{
    public static class ImageArchiveExtensions
    {
        /// <summary>
        /// 截取 copyright。
        /// </summary>
        /// <param name="imageArchive"></param>
        /// <returns></returns>
        public static string GetCopyright(this ImageArchive imageArchive)
        {
            string copyright = imageArchive.Copyright;
            int index = copyright.IndexOf('(');
            if (index > -1)
            {
                copyright = copyright.Substring(0, index).Trim();
            }
            return copyright;
        }

        public static DateTime GetEndDate(this ImageArchive imageArchive)
        {
            return DateTimeHelper.Parse(imageArchive.EndDate);
        }

        /// <summary>
        /// 如果存在 message，则设置为第一个 message 的 text。否则返回 null。
        /// </summary>
        /// <param name="imageArchive"></param>
        /// <returns></returns>
        public static string GetFirstMessageIfExist(this ImageArchive imageArchive)
        {
            Message[] messages = imageArchive.Messages;
            return messages == null
                ? null
                : messages.Select(temp => temp.Text).FirstOrDefault(temp => string.IsNullOrEmpty(temp) == false);
        }

        public static DateTime GetFullStartDate(this ImageArchive imageArchive)
        {
            return DateTimeHelper.Parse(imageArchive.FullStartDate);
        }

        public static DateTime GetStartDate(this ImageArchive imageArchive)
        {
            return DateTimeHelper.Parse(imageArchive.StartDate);
        }

        /// <summary>
        /// 如果存在 message，则以 message 作为壁纸的标题，否则截取 copyright。
        /// </summary>
        /// <param name="imageArchive"></param>
        /// <returns></returns>
        public static string GetTitle(this ImageArchive imageArchive)
        {
            string title = imageArchive.GetFirstMessageIfExist();
            if (string.IsNullOrEmpty(title))
            {
                title = imageArchive.GetCopyright();
            }
            return title;
        }

        public static string GetUrlWithSize(this ImageArchive imageArchive, WallpaperSize size)
        {
            if (imageArchive == null)
            {
                return null;
            }
            return string.Format("http://www.bing.com{0}_{1}.jpg", imageArchive.UrlBase, size.GetName());
        }
    }
}