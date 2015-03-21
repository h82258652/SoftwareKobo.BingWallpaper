// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供
using SoftwareKobo.BingWallpaper.Datas;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.BingWallpaper.Views
{
    public sealed partial class SettingHub : UserControl
    {
        public SettingHub()
        {
            this.InitializeComponent();
        }

        private void CmbArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 重新加载壁纸信息。
            Global.WallpaperCollection.Reset();

            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null)
            {
                MainPage mainPage = rootFrame.Content as MainPage;
                if (mainPage != null)
                {
                    // 重新加载主页背景。
                    // 更新主磁贴为所选区域。
                    mainPage.ViewModel.Init();
                }
            }
        }
    }
}