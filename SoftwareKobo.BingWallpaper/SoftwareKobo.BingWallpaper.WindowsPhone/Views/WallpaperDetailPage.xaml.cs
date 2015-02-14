﻿// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

using System;
using Windows.System;
using Windows.UI.Xaml;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;
using SoftwareKobo.BingWallpaper.WindowsPhone.Interfaces;
using SoftwareKobo.BingWallpaper.WindowsPhone.ViewModels;
using Windows.ApplicationModel.Activation;
using Windows.Phone.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class WallpaperDetailPage : Page, IContinueFileSave
    {
        public WallpaperDetailPage()
        {
            this.InitializeComponent();
        }

        public WallpaperDetailPageViewModel ViewModel
        {
            get
            {
                return (WallpaperDetailPageViewModel)DataContext;
            }
        }

        public void ContinueFileSave(FileSavePickerContinuationEventArgs fileSavePickerContinuationEventArgs)
        {
            IContinueFileSave continueFileSave = this.DataContext as IContinueFileSave;
            if (continueFileSave != null)
            {
                continueFileSave.ContinueFileSave(fileSavePickerContinuationEventArgs);
            }
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;

            var statusBar = StatusBar.GetForCurrentView();
            await statusBar.ShowAsync();
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            
            ViewModel.ImageArchive = e.Parameter as ImageArchive;

            var statusBar = StatusBar.GetForCurrentView();
            await statusBar.HideAsync();
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private async void BtnNavigateLockScreenSetting_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
        }
    }
}