using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace SoftwareKobo.BingWallpaper.Controls
{
    public static class SideToastService
    {
        public static readonly DependencyProperty PopupProperty = DependencyProperty.RegisterAttached("Popup", typeof(Popup), typeof(SideToastService), new PropertyMetadata(null));

        public static Popup GetPopup(DependencyObject obj)
        {
            return (Popup)obj.GetValue(PopupProperty);
        }

        public static void Hide(this SideToast toast)
        {
            DoubleAnimation translateAnimation = new DoubleAnimation();
            translateAnimation.From = 0;
            if (toast.Location == ToastLocation.Right)
            {
                translateAnimation.To = toast.ContentWidth;
            }
            else if (toast.Location == ToastLocation.Left)
            {
                translateAnimation.To = 0 - toast.ContentWidth;
            }
            translateAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5d));
            Storyboard.SetTarget(translateAnimation, toast.LayoutTransform);
            Storyboard.SetTargetProperty(translateAnimation, "X");

            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 1.0d;
            opacityAnimation.To = 0.5d;
            opacityAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5d));
            Storyboard.SetTarget(opacityAnimation, toast);
            Storyboard.SetTargetProperty(opacityAnimation, "Opacity");

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(translateAnimation);
            storyboard.Children.Add(opacityAnimation);

            storyboard.Completed += (sender, e) =>
            {
                // 释放引用。
                Popup popup = GetPopup(toast);
                popup.IsOpen = false;
                popup.Child = null;

                // 重置原位。
                toast.LayoutTransform.X = 0;
                // 重置可见度。
                toast.Opacity = 1.0d;
            };

            storyboard.Begin();
        }

        public static void SetPopup(DependencyObject obj, Popup value)
        {
            obj.SetValue(PopupProperty, value);
        }

        public static void Show(string message, int milliseconds)
        {
            SideToast toast = new SideToast(message);
            toast.Margin = new Thickness(0, 80, 0, 0);
            Show(toast, milliseconds);
        }

        public static void Show(this SideToast toast)
        {
            Show(toast, 0);
        }

        public static void Show(this SideToast toast, int milliseconds)
        {
            if (toast == null)
            {
                throw new ArgumentNullException("toast");
            }

            // 设置到无法显示的位置，防止动画开始时闪烁。
            switch (toast.Location)
            {
                case ToastLocation.Right:
                    toast.LayoutTransform.X = Window.Current.Bounds.Width;
                    break;

                case ToastLocation.Left:
                    toast.LayoutTransform.X = 0 - Window.Current.Bounds.Width;
                    break;

                default:
                    throw new InvalidOperationException("toast location only can left or right.");
            }

            Popup popup = GetPopup(toast);
            if (popup == null)
            {
                popup = new Popup();
                SetPopup(toast, popup);
            }
            if (popup.Child == null)
            {
                popup.Child = toast;
            }

            Frame frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigated += (sender, e) =>
                {
                    Hide(toast);
                    popup.IsOpen = false;
                };
            }

            popup.Opened += Popup_Opened;

            popup.IsOpen = true;

            if (milliseconds <= 0)
            {
                return;
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(milliseconds);
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                Hide(toast);
            };
            timer.Start();
        }

        private static void Popup_Opened(object sender, object e)
        {
            Popup popup = (Popup)sender;
            SideToast toast = (SideToast)popup.Child;

            DoubleAnimation animation = new DoubleAnimation();
            if (toast.Location == ToastLocation.Right)
            {
                animation.From = toast.ContentWidth;
            }
            else if (toast.Location == ToastLocation.Left)
            {
                animation.From = 0 - toast.ContentWidth;
            }
            animation.To = 0;
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.6d));
            animation.EasingFunction = new BounceEase()
            {
                Bounces = 3,
                Bounciness = 6
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, toast.LayoutTransform);
            Storyboard.SetTargetProperty(animation, "X");

            storyboard.Begin();
        }
    }
}