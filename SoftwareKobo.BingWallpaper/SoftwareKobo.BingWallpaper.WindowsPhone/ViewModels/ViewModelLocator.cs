using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using SoftwareKobo.BingWallpaper.WindowsPhone.Views;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // TODO
            }
            else
            {
                SimpleIoc.Default.Register<IBingWallpaperService, BingWallpaperJsonService>();
            }

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<SettingHubViewModel>();
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
            get { return ServiceLocator.Current.GetInstance<SettingHubViewModel>(); }
        }
    }
}