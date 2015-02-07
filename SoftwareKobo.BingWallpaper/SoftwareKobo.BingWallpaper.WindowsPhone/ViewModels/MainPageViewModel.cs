using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.Datas;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        public WallpaperSize SelectedWallpaperSize
        {
            get { return Settings.WallpaperSize; }
            set
            {
                Settings.WallpaperSize = value;
                RaisePropertyChanged(()=>SelectedWallpaperSize);
            }
        }

        private ObservableCollection<KeyValuePair<string, WallpaperSize>> _wallpaperSizes;

        public ObservableCollection<KeyValuePair<string,WallpaperSize>> WallpaperSizes
        {
            get { return _wallpaperSizes; }
            set
            {
                _wallpaperSizes = value;
                RaisePropertyChanged(()=>WallpaperSizes);
            }
        }

        public MainPageViewModel()
        {
            WallpaperSizes=new ObservableCollection<KeyValuePair<string, WallpaperSize>>();
            WallpaperSizes.CollectionChanged += (sender,e) => RaisePropertyChanged(() => SelectedWallpaperSize);
            
            var enums = Enum.GetValues(typeof (WallpaperSize)).Cast<WallpaperSize>();
            foreach (var wallpaperSize in enums)
            {
                string name = wallpaperSize.GetName();
                if (wallpaperSize==WallpaperSizeHelper.GetDefaultSize())
                {
                    name = name + "";
                }
                WallpaperSizes.Add(new KeyValuePair<string, WallpaperSize>(name,wallpaperSize));
            }
        }
    }
}
