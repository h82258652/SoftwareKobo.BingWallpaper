using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Datas;
using SoftwareKobo.BingWallpaper.Helpers;
using SoftwareKobo.BingWallpaper.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareKobo.BingWallpaper.ViewModels
{
    public class SettingHubViewModel : ViewModelBase
    {
        private readonly string[] _allSaveLocation = new string[]
        {
            ResourcesHelper.PictureLibrary,
            ResourcesHelper.ChooseEveryTime
        };

        private readonly string[] _areas = new string[]
        {
            "de-DE",
            "en-AU",
            "en-CA",
            "en-NZ",
            "en-UK",
            "en-US",
            "ja-JP",
            "zh-CN",
        };

        private readonly List<WallpaperSize> _wallpaperSizes = new List<WallpaperSize>(Enum.GetValues(typeof(WallpaperSize)).Cast<WallpaperSize>());

        public string[] AllSaveLocation
        {
            get
            {
                return _allSaveLocation;
            }
        }

        public string Area
        {
            get
            {
                return Settings.Area;
            }
            set
            {
                Settings.Area = value;
                RaisePropertyChanged(() => Area);
            }
        }

        public string[] Areas
        {
            get
            {
                return _areas;
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