using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace SoftwareKobo.BingWallpaper.Controls
{
    [ContentProperty(Name = "ToastContent")]
    public sealed partial class SideToast : UserControl
    {
        public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(ToastLocation), typeof(SideToast), new PropertyMetadata(ToastLocation.Right, OnLocationChanged));

        public static readonly DependencyProperty ToastContentProperty = DependencyProperty.Register("ToastContent", typeof(object), typeof(SideToast), new PropertyMetadata(null, OnToastContentChanged));

        public SideToast()
        {
            this.InitializeComponent();

            this.Loaded += SideToast_Loaded;
            this.Unloaded += SideToast_Unloaded;
            ReSize();
        }

        public SideToast(string message)
            : this()
        {
            this.ToastContent = message;
        }

        public double ContentHeight
        {
            get
            {
                return brdContent.ActualHeight;
            }
        }

        public double ContentWidth
        {
            get
            {
                return brdContent.ActualWidth;
            }
        }

        public TranslateTransform LayoutTransform
        {
            get
            {
                return translate;
            }
        }

        public ToastLocation Location
        {
            get
            {
                return (ToastLocation)GetValue(LocationProperty);
            }
            set
            {
                SetValue(LocationProperty, value);
            }
        }

        public object ToastContent
        {
            get
            {
                return GetValue(ToastContentProperty);
            }
            set
            {
                SetValue(ToastContentProperty, value);
            }
        }

        private static void OnLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SideToast toast = (SideToast)d;
            ToastLocation value = (ToastLocation)e.NewValue;
            if (value == ToastLocation.Right)
            {
                toast.brdContent.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else if (value == ToastLocation.Left)
            {
                toast.brdContent.HorizontalAlignment = HorizontalAlignment.Left;
            }
        }

        private static void OnToastContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SideToast toast = (SideToast)d;
            object value = e.NewValue;
            toast.cclContent.Content = value;
        }

        private void ReSize()
        {
            Rect size = Window.Current.Bounds;
            this.Width = size.Width;
            this.Height = size.Height;
        }

        private void SideToast_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += Window_SizeChanged;
        }

        private void SideToast_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            ReSize();
        }
    }
}