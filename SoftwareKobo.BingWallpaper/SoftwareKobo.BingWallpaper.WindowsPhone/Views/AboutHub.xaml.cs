using System;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.Store;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace SoftwareKobo.BingWallpaper.Views
{
    public sealed partial class AboutHub : UserControl
    {
        public AboutHub()
        {
            this.InitializeComponent();
        }

        private async void BtnAdvise_Click(object sender, RoutedEventArgs e)
        {
            EmailMessage email = new EmailMessage();
            email.To.Add(new EmailRecipient("h82258652@hotmail.com"));
            email.Subject = "BingWallpaper advise";
            await EmailManager.ShowComposeNewEmailAsync(email);
        }

        private async void BtnGivePraise_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
        }
    }
}