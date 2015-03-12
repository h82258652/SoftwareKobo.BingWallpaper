using GalaSoft.MvvmLight.Ioc;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;

namespace SoftwareKobo.BingWallpaper.Datas
{
    public class Global
    {
        private static WallpaperCollection _wallpaperCollection;

        public static WallpaperCollection WallpaperCollection
        {
            get
            {
                _wallpaperCollection = _wallpaperCollection ?? new WallpaperCollection(SimpleIoc.Default.GetInstance<IBingWallpaperService>());
                return _wallpaperCollection;
            }
        }
    }
}