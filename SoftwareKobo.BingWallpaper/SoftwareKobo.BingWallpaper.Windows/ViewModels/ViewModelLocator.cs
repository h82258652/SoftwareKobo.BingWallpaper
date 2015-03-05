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
            SimpleIoc.Default.Register<IBingWallpaperService, BingWallpaperJsonService>();

            // 注册 ViewModel。
            SimpleIoc.Default.Register<ApplicationSettingFlyoutViewModel>();
        }

        public ApplicationSettingFlyoutViewModel Setting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ApplicationSettingFlyoutViewModel>();
            }
        }
    }
}