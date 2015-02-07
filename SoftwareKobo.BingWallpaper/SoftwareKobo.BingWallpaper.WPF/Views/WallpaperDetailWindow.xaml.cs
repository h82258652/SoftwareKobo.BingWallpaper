using System.Windows;
using MahApps.Metro.Controls;
using SoftwareKobo.BingWallpaper.WPF.ViewModels;
using System.Windows.Input;

namespace SoftwareKobo.BingWallpaper.WPF.Views
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

            wallpaperScrollViewer.PreviewMouseDown += WallpaperScrollViewer_PreviewMouseDown;
        }

        void WallpaperScrollViewer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}