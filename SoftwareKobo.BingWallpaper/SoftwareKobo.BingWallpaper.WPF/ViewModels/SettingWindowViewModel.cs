using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.Datas;
using SoftwareKobo.BingWallpaper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareKobo.BingWallpaper.ViewModels
{
    public class SettingWindowViewModel : ViewModelBase
    {
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

        private Dictionary<string, WallpaperSize> _wallpaperSizes;

        public Dictionary<string, WallpaperSize> WallpaperSizes
        {
            get
            {
                return _wallpaperSizes;
            }
            set
            {
                _wallpaperSizes = value;
                RaisePropertyChanged(() => WallpaperSizes);
            }
        }

        public SettingWindowViewModel()
        {
            WallpaperSizes = new Dictionary<string, WallpaperSize>();

            var enums = Enum.GetValues(typeof(WallpaperSize)).Cast<WallpaperSize>();
            foreach (var wallpaperSize in enums)
            {
                string name = wallpaperSize.GetName();
                if (wallpaperSize == WallpaperSizeHelper.GetDefaultsSize())
                {
                    name = name + Properties.Resources.Default;
                }
                WallpaperSizes.Add(name, wallpaperSize);
            }
        }
    }
}