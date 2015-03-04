using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.AvalonDock.Controls;

namespace SoftwareKobo.BingWallpaper.Controls
{
    /// <summary>
    /// WallpaperThumbControl.xaml 的交互逻辑
    /// </summary>
    public partial class WallpaperThumbControl : UserControl
    {
        public WallpaperThumbControl()
        {
            InitializeComponent();

            // 控制 Popup。
            this.MouseEnter += WallpaperThumbControl_MouseEnter;
            this.MouseLeave += WallpaperThumbControl_MouseLeave;
            this.MouseWheel += WallpaperThumbControl_MouseWheel;
            toolTipPopup.MouseLeave += ToolTipPopup_MouseLeave;

            // 点击事件。
            this.MouseUp += WallpaperThumbControl_MouseUp;
            this.KeyUp += WallpaperThumbControl_KeyUp;
        }

        void WallpaperThumbControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter||e.Key==Key.Space)
            {
                RaiseClickEvent();
            }
            e.Handled = true;
        }

        public event RoutedEventHandler Click;

        private void RaiseClickEvent()
        {
            if (Click != null)
            {
                Click(this, new RoutedEventArgs());
            }
        }

        private void ToolTipPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.IsMouseOver == false)
            {
                toolTipPopup.IsOpen = false;
            }
        }

        private void WallpaperThumbControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Window parentWindow = this.FindLogicalAncestor<Window>();
            Point positionInWindow = this.TranslatePoint(new Point(), parentWindow);
            if (positionInWindow.X + this.ActualWidth > parentWindow.ActualWidth)
            {
                return;
            }

            toolTipPopup.IsOpen = true;
        }

        private void WallpaperThumbControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (toolTipPopup.IsMouseOver == false)
            {
                toolTipPopup.IsOpen = false;
            }
        }

        private void WallpaperThumbControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                RaiseClickEvent();
            }
        }

        private void WallpaperThumbControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            toolTipPopup.IsOpen = false;
        }
    }
}