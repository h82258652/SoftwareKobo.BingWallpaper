using SoftwareKobo.BingWallpaper.WindowsPhone.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public static class SideToastHelper
    {
        public static void Success(string message)
        {
            Show(new SymbolIcon(Symbol.Accept), message);
        }

        public static void Error(string message)
        {
            Show(new SymbolIcon(Symbol.Cancel), message);
        }

        private static void Show(SymbolIcon icon, string message)
        {
            SideToast toast = new SideToast()
            {
                Margin = new Thickness(0, 80, 0, 0)
            };
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            icon.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.Children.Add(icon);
            stackPanel.Children.Add(new TextBlock()
            {
                Text = message,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap
            });
            toast.ToastContent = stackPanel;
            toast.Show(3000);
        }
    }
}