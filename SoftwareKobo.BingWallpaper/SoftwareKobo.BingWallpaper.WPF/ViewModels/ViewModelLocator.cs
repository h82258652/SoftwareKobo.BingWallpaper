using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.Services.Interfaces;

namespace SoftwareKobo.BingWallpaper.WPF.ViewModels
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

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<SettingWindowViewModel>();
            SimpleIoc.Default.Register<WallpaperDetailWindowViewModel>();
        }

        public MainWindowViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        public SettingWindowViewModel Setting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingWindowViewModel>();
            }
        }

        public WallpaperDetailWindowViewModel WallpaperDetail
        {
            get { return ServiceLocator.Current.GetInstance<WallpaperDetailWindowViewModel>(); }
        }
    }
}