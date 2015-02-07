using System.Windows.Controls;
using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SoftwareKobo.BingWallpaper.WPF.Helpers;
using SoftwareKobo.BingWallpaper.WPF.Properties;
using Settings = SoftwareKobo.BingWallpaper.WPF.Datas.Settings;

namespace SoftwareKobo.BingWallpaper.WPF.ViewModels
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

        private ObservableCollection<KeyValuePair<string, WallpaperSize>> _wallpaperSizes;

        public ObservableCollection<KeyValuePair<string, WallpaperSize>> WallpaperSizes
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
            WallpaperSizes = new ObservableCollection<KeyValuePair<string, WallpaperSize>>();
            WallpaperSizes.CollectionChanged += (sender,e) => RaisePropertyChanged(()=>SelectedWallpaperSize);

            var enums = Enum.GetValues(typeof(WallpaperSize)).Cast<WallpaperSize>();
            foreach (var wallpaperSize in enums)
            {
                string name = wallpaperSize.GetName();
                if (wallpaperSize==WallpaperSizeHelper.GetDefaultsSize())
                {
                    name = name + Resources.Default;
                }
                WallpaperSizes.Add(new KeyValuePair<string, WallpaperSize>(name, wallpaperSize));
            }
        }
    }
}