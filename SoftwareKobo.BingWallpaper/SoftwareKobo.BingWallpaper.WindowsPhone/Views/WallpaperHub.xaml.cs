// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

using SoftwareKobo.BingWallpaper.ViewModels;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.BingWallpaper.Views
{
    public sealed partial class WallpaperHub : UserControl
    {
        public WallpaperHubViewModel ViewModel
        {
            get
            {
                return (WallpaperHubViewModel)DataContext;
            }
        }

        public WallpaperHub()
        {
            this.InitializeComponent();
        }
    }
}