using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
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

        public int TotalCount
        {
            get
            {
                return WallpaperThumbnails.Count;
            }
        }

        public MainWindowViewModel(IBingWallpaperService bingWallpaperService)
        {
            _bingWallpaperService = bingWallpaperService;

            Start();
        }

        protected async void Start()
        {
            WallpaperThumbnails = new ObservableCollection<ImageArchive>();
            WallpaperThumbnails.CollectionChanged += (sender, e) => RaisePropertyChanged(() => TotalCount);
            await LoadWallpaper(8);
        }

        private ObservableCollection<ImageArchive> _wallpaperThumbsnails;

        public ObservableCollection<ImageArchive> WallpaperThumbnails
        {
            get
            {
                return _wallpaperThumbsnails;
            }
            set
            {
                _wallpaperThumbsnails = value;
                RaisePropertyChanged(() => WallpaperThumbnails);
            }
        }

        private ICommand _loadCommand;

        private bool _loading;

        public ICommand LoadCommand
        {
            get
            {
                _loadCommand = _loadCommand ?? new RelayCommand(() => LoadWallpaper(4));
                return _loadCommand;
            }
        }

        private async Task LoadWallpaper(int count)
        {
            if (_loading)
            {
                return;
            }
            _loading = true;
            ImageArchiveCollection imageArchiveCollection = await _bingWallpaperService.GetWallpaperInformationsAsync(WallpaperThumbnails.Count, count, CultureInfo.CurrentCulture);
            if (imageArchiveCollection == null)
            {
                _loading = false;
                return;
            }
            ImageArchive[] imageArchives = imageArchiveCollection.Images;
            foreach (var imageArchive in imageArchives)
            {
                if (WallpaperThumbnails.Count(temp => temp.UrlBase == imageArchive.UrlBase) <= 0)
                {
                    WallpaperThumbnails.Add(imageArchive);
                }
            }
            _loading = false;
        }
    }
}