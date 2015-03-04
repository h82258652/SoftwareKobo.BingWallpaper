using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using SoftwareKobo.BingWallpaper.Helpers;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SoftwareKobo.BingWallpaper.Views;

namespace SoftwareKobo.BingWallpaper.ViewModels
{
    public class WallpaperHubViewModel : ViewModelBase
    {
        private WallpaperCollection _wallpaperCollection;

        public WallpaperCollection WallpaperCollection
        {
            get
            {
                return _wallpaperCollection;
            }
            set
            {
                _wallpaperCollection = value;
                RaisePropertyChanged(() => WallpaperCollection);
            }
        }

        public WallpaperHubViewModel()
        {
            WallpaperCollection = new WallpaperCollection(SimpleIoc.Default.GetInstance<IBingWallpaperService>());

            if (IsInDesignModeStatic == false)
            {
                this.WallpaperCollection.OnLoadMoreStarted += WallpaperCollection_OnLoadMoreStarted;
                this.WallpaperCollection.OnLoadMoreCompleted += WallpaperCollection_OnLoadMoreCompleted;
            }
        }

        private async void WallpaperCollection_OnLoadMoreStarted(object sender, int e)
        {
            StatusBar statusBar = StatusBar.GetForCurrentView();
            statusBar.ProgressIndicator.Text = ResourcesHelper.NowLoading;
            await statusBar.ProgressIndicator.ShowAsync();
        }

        private async void WallpaperCollection_OnLoadMoreCompleted(object sender, int e)
        {
            StatusBar statusBar = StatusBar.GetForCurrentView();
            statusBar.ProgressIndicator.Text = string.Empty;
            await statusBar.ProgressIndicator.HideAsync();
        }

        private RelayCommand<ItemClickEventArgs> _clickCommand;

        public RelayCommand<ItemClickEventArgs> ClickCommand
        {
            get
            {
                _clickCommand = _clickCommand ?? new RelayCommand<ItemClickEventArgs>(args =>
                {
                    ImageArchive imageArchive = args.ClickedItem as ImageArchive;
                    if (imageArchive == null)
                    {
                        return;
                    }

                    Frame rootFrame = Window.Current.Content as Frame;
                    if (rootFrame == null)
                    {
                        return;
                    }

                    rootFrame.Navigate(typeof(WallpaperDetailPage), imageArchive);
                });
                return _clickCommand;
            }
        }
    }
}