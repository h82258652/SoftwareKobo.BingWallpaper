using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.Datas;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.ViewModels
{
    public class SettingHubViewModel : ViewModelBase
    {
        private readonly string[] _allSaveLocation = new string[]
        {
            ResourcesHelper.PictureLibrary,
            ResourcesHelper.ChooseEveryTime
        };

        private readonly List<WallpaperSize> _wallpaperSizes = new List<WallpaperSize>(Enum.GetValues(typeof(WallpaperSize)).Cast<WallpaperSize>());

        public string[] AllSaveLocation
        {
            get
            {
                return _allSaveLocation;
            }
        }

        public string SaveLocation
        {
            get
            {
                return Settings.SaveLocation;
            }
            set
            {
                Settings.SaveLocation = value;
                RaisePropertyChanged(() => SaveLocation);
            }
        }

        public WallpaperSize SelectedWallpaperSize
        {
            get
            {
                return Settings.WallpaperSize;
            }
            set
            {
                Settings.WallpaperSize = value;
                RaisePropertyChanged(() => SelectedWallpaperSize);
            }
        }

        public List<WallpaperSize> WallpaperSizes
        {
            get
            {
                return _wallpaperSizes;
            }
        }
    }
}