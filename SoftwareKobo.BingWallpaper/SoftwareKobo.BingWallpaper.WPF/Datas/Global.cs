using GalaSoft.MvvmLight.Ioc;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.Datas
{
    public static class Global
    {
        private readonly static IBingWallpaperService BingWallpaperService;

        static Global()
        {
            BingWallpaperService = SimpleIoc.Default.GetInstance<IBingWallpaperService>();
        }

        private static ObservableCollection<ImageArchive> _loadImageArchives;

        /// <summary>
        /// 所有已经加载的壁纸信息。
        /// </summary>
        public static ObservableCollection<ImageArchive> LoadedImageArchives
        {
            get
            {
                _loadImageArchives = _loadImageArchives ?? new ObservableCollection<ImageArchive>();
                return _loadImageArchives;
            }
        }

        private static bool _loading;

        public async static Task LoadMore(int count)
        {
            if (_loading)
            {
                return;
            }
            ImageArchiveCollection imageArchiveCollection =
                await
                    BingWallpaperService.GetWallpaperInformationsAsync(LoadedImageArchives.Count, count,
                        CultureInfo.CurrentCulture.Name);
            if (imageArchiveCollection != null)
            {
                ImageArchive[] imageArchives = imageArchiveCollection.Images;
                foreach (var imageArchive in imageArchives)
                {
                    if (LoadedImageArchives.Any(temp => temp.UrlBase == imageArchive.UrlBase) == false)
                    {
                        LoadedImageArchives.Add(imageArchive);
                    }
                }
            }
            _loading = false;
        }
    }
}