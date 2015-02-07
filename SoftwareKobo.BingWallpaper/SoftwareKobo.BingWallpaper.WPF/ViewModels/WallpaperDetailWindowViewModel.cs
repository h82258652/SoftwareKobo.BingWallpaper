using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WPF.Datas;

namespace SoftwareKobo.BingWallpaper.WPF.ViewModels
{
    public class WallpaperDetailWindowViewModel : ViewModelBase
    {
        private ImageArchive _imageArchive;

        public ImageArchive ImageArchive
        {
            get
            {
                return _imageArchive;
            }
            set
            {
                _imageArchive = value;
                RaisePropertyChanged(() => ImageArchive);
                RaisePropertyChanged(()=>WallpaperUrl);
            }
        }

        public string WallpaperUrl
        {
            get
            {
               return ImageArchive.GetUrlWithSize(Settings.WallpaperSize);
            }
        }
    }
}
