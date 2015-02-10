﻿// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;
using SoftwareKobo.BingWallpaper.WindowsPhone.ViewModels;
using SoftwareKobo.BingWallpaper.WindowsPhone.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SoftwareKobo.BingWallpaper.WindowsPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.DataContext = new MainPageViewModel();
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
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WallpaperDetailPage));
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            //var comboBox = (ComboBox)sender;

            //var enums = Enum.GetValues(typeof(WallpaperSize)).Cast<WallpaperSize>().ToList();
            //var defaultSize = WallpaperSizeHelper.GetDefaultSize();
            //for (int i = 0; i < enums.Count; i++)
            //{
            //    var wallpaperSize = enums[i];
            //    string name = wallpaperSize.GetName();
            //    if (wallpaperSize == defaultSize)
            //    {
            //        name = name + ResourcesHelper.Default;
            //    }
            //    comboBox.Items.Add(wallpaperSize);
            //    if (wallpaperSize == defaultSize)
            //    {
            //        comboBox.SelectedIndex = i;
            //    }
            //}
        }
    }
}