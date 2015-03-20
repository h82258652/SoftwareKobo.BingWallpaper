// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

using System;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace SoftwareKobo.BingWallpaper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // 记录后退键按下次数。
        private int _backPressCount = 0;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;

            if (_backPressCount > 0)
            {
                // 再次按下后退键，退出。
                Application.Current.Exit();
            }

            _backPressCount++;

            DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.0d)),
                Value = 1.0d
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.5d)),
                Value = 0.8d
            });
            animation.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.0d)),
                Value = 0.0d
            });

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, brdExit);
            Storyboard.SetTargetProperty(animation, "Opacity");

            // 显示退出提示。
            brdExit.Visibility = Visibility.Visible;

            storyboard.Completed += (storyboardCompletedSender, args) =>
            {
                // 重置后退键按下次数。
                _backPressCount = 0;
                storyboard.Stop();
                brdExit.Opacity = 0.0d;

                // 隐藏退出提示。
                brdExit.Visibility = Visibility.Collapsed;
            };
            storyboard.Begin();
        }
    }
}