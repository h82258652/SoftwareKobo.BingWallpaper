using SoftwareKobo.BingWallpaper.Services;
using System;
using System.Globalization;
using Windows.Foundation;

namespace SoftwareKobo.BingWallpaper.Helpers
{
    public static class WallpaperSizeHelper
    {
        /// <summary>
        /// 根据当前设备的分辨率获取默认壁纸大小。
        /// </summary>
        /// <returns>壁纸大小。</returns>
        public static WallpaperSize GetDefaultSize()
        {
            Size size = DisplayInformationHelper.GetSize();
            double width = size.Width;
            double height = size.Height;

            WallpaperSize wallpaperSize;
            if (Enum.TryParse(string.Format(CultureInfo.InvariantCulture, "_{0}x{1}", width, height), out wallpaperSize))
            {
                return wallpaperSize;
            }
            else
            {
                // 设备分辨率未定义在枚举中，返回 480x800 作为默认值。
                return WallpaperSize._480x800;
            }
        }
    }
}