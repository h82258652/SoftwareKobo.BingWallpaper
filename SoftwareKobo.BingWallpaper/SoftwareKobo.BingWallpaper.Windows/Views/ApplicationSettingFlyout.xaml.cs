using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Controls;

//“设置浮出控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=273769 上有介绍

namespace SoftwareKobo.BingWallpaper.Views
{
    public sealed partial class ApplicationSettingFlyout : SettingsFlyout
    {
        public ApplicationSettingFlyout()
        {
            this.InitializeComponent();
        }

        public static void RegisterToCharmBar()
        {
            SettingsPane.GetForCurrentView().CommandsRequested += (sender, e) => e.Request.ApplicationCommands.Add(new SettingsCommand("s", "ss", handler => new ApplicationSettingFlyout().Show()));
        }
    }
}