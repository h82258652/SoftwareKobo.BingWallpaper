using System;
using Windows.ApplicationModel.Store;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Views
{
    public sealed partial class AboutHub : UserControl
    {
        public AboutHub()
        {
            this.InitializeComponent();
        }

        private async void BtnGivePraise_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:navigate?reviewapp?appid=" + CurrentApp.AppId));
        }
    }
}