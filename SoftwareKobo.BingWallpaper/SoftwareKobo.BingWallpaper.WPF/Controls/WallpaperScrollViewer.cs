using GalaSoft.MvvmLight;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.AvalonDock.Controls;

namespace SoftwareKobo.BingWallpaper.WPF.Controls
{
    public class WallpaperScrollViewer : ScrollViewer
    {
        private ScrollBar _horizontalScrollBar;
        private ScrollBar _verticalScrollBar;

        public WallpaperScrollViewer()
            : base()
        {
            if (ViewModelBase.IsInDesignModeStatic == false)
            {
                Cursor = new Cursor(Application.GetResourceStream(new Uri("/Assets/desktop_view.cur", UriKind.Relative)).Stream);
            }

            this.CanContentScroll = true;

            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            this.VerticalScrollBarVisibility= ScrollBarVisibility.Hidden;

            PreviewMouseDown += WallpaperScrollViewer_PreviewMouseDown;
            MouseMove += WallpaperScrollViewer_MouseMove;
            PreviewMouseUp += WallpaperScrollViewer_PreviewMouseUp;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var scrollBars = this.FindVisualChildren<ScrollBar>();
            _horizontalScrollBar = scrollBars.Single(temp => temp.Orientation == Orientation.Horizontal);
            _verticalScrollBar = scrollBars.Single(temp => temp.Orientation == Orientation.Vertical);
        }

        private Point? _lastMovePosition;

        private void WallpaperScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(null);
                double deltaX = currentPosition.X - _lastMovePosition.Value.X;
                double deltaY = currentPosition.Y - _lastMovePosition.Value.Y;

                this.ScrollToHorizontalOffset(this.HorizontalOffset - deltaX);
                this.ScrollToVerticalOffset(this.VerticalOffset - deltaY);

                _lastMovePosition = currentPosition;
            }
        }

        private void WallpaperScrollViewer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _lastMovePosition = e.GetPosition(null);
            }
        }

        private void WallpaperScrollViewer_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _lastMovePosition = null;
            }
        }
    }
}