// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

using SoftwareKobo.BingWallpaper.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

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

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            // 多并发下会导致图片加载失败。
            Image image = (Image)sender;
            BitmapImage bitmap = image.Source as BitmapImage;
            if (bitmap != null)
            {
                string thumbUrl = bitmap.UriSource.OriginalString;
                // 重新设定 Image 的源，加载缩略图。
                image.Source = new BitmapImage(new Uri(thumbUrl, UriKind.Absolute));
            }
        }
    }
}