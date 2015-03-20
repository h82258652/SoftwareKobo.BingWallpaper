using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.Services.Interfaces;

namespace SoftwareKobo.BingWallpaper.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // 注册服务。
            SimpleIoc.Default.Register<IBingWallpaperService, BingWallpaperJsonProxyService>();

            // 注册 ViewModel。
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<WallpaperHubViewModel>();
            SimpleIoc.Default.Register<SettingHubViewModel>();
            SimpleIoc.Default.Register<WallpaperDetailPageViewModel>();
        }

        public MainPageViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public SettingHubViewModel Setting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingHubViewModel>();
            }
        }

        public WallpaperHubViewModel Wallpaper
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WallpaperHubViewModel>();
            }
        }

        public WallpaperDetailPageViewModel WallpaperDetail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WallpaperDetailPageViewModel>();
            }
        }
    }
}