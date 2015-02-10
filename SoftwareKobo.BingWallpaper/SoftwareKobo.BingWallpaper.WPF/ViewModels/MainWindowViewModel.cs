using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using SoftwareKobo.BingWallpaper.WPF.Datas;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoftwareKobo.BingWallpaper.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IBingWallpaperService _bingWallpaperService;

        public MainWindowViewModel(IBingWallpaperService bingWallpaperService)
        {
            _bingWallpaperService = bingWallpaperService;

            Start();
        }

        protected async void Start()
        {
            await Global.LoadMore(8);
        }

        public ObservableCollection<ImageArchive> WallpaperThumbnails
        {
            get
            {
                return Global.LoadedImageArchives;
            }
        }

        private ICommand _loadCommand;
        
        public ICommand LoadCommand
        {
            get
            {
                _loadCommand = _loadCommand ?? new RelayCommand(() => Global.LoadMore(4));
                return _loadCommand;
            }
        }
    }
}