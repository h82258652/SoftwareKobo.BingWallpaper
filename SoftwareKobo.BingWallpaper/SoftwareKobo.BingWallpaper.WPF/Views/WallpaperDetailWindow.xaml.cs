using MahApps.Metro.Controls;
using SoftwareKobo.BingWallpaper.ViewModels;

namespace SoftwareKobo.BingWallpaper.Views
{
    /// <summary>
    /// WallpaperDetailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WallpaperDetailWindow : MetroWindow
    {
        public WallpaperDetailWindowViewModel ViewModel
        {
            get
            {
                return (WallpaperDetailWindowViewModel)DataContext;
            }
        }

        public WallpaperDetailWindow()
        {
            InitializeComponent();
        }
    }
}