using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System.Globalization;
using System.Linq;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IBingWallpaperService _bingWallpaperService;

        private string _backgroundUrl;

        public string BackgroundUrl
        {
            get
            {
                return _backgroundUrl;
            }
            private set
            {
                _backgroundUrl = value;
                RaisePropertyChanged(() => BackgroundUrl);
            }
        }

        public MainPageViewModel(IBingWallpaperService bingWallpaperService)
        {
            _bingWallpaperService = bingWallpaperService;

            if (IsInDesignMode == false)
            {
                Start();
            }
        }

        protected async void Start()
        {
            ImageArchiveCollection imageArchiveCollection = await _bingWallpaperService.GetWallpaperInformationsAsync(0, 1, CultureInfo.CurrentCulture);
            if (imageArchiveCollection != null)
            {
                ImageArchive imageArchive = imageArchiveCollection.Images.FirstOrDefault();
                if (imageArchive != null)
                {
                    BackgroundUrl = imageArchive.GetUrlWithSize(WallpaperSize._1920x1080);
                    TileHelper.UpdateTile(imageArchive);
                }
            }
        }
    }
}