using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class WallpaperDetailPage : Page
    {
        public WallpaperDetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var file = await Windows.Storage.KnownFolders.PicturesLibrary.CreateFileAsync("test.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, "");
            return;

            FileSavePicker savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add(".jpg", new List<string>() { ".jpg" });
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.PickSaveFileAndContinue();
        }

        internal void ContinueFileSave(FileSavePickerContinuationEventArgs fileSavePickerContinuationEventArgs)
        {
            StorageFile file = fileSavePickerContinuationEventArgs.File;
            if (file != null)
            {
            }
        }
    }
}