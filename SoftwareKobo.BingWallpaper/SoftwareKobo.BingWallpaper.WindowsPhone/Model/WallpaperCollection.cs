using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Model
{
    public class WallpaperCollection : IncrementalLoadingCollection<ImageArchive>
    {
        private readonly IBingWallpaperService _bingWallpaperService;

        public WallpaperCollection(IBingWallpaperService bingWallpaperService)
        {
            _bingWallpaperService = bingWallpaperService;
        }

        public override bool HasMoreItems
        {
            get
            {
                return _isEnd == false;
            }
        }

        private bool _isEnd = false;

        protected override async Task<IEnumerable<ImageArchive>> LoadMoreItems(CancellationToken c, int count)
        {
            ImageArchiveCollection imageArchiveCollection = await _bingWallpaperService.GetWallpaperInformationsAsync(this.Count, count, CultureInfo.CurrentCulture);
            if (imageArchiveCollection == null)
            {
                _isEnd = true;
                return null;
            }
            else
            {
                return imageArchiveCollection.Images;
            }
        }

        protected override void AddItems(IEnumerable<ImageArchive> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (this.Any(temp => temp.UrlBase == item.UrlBase) == false)
                    {
                        Add(item);
                    }
                }
            }
        }
    }

    //public class WallpaperCollection : ObservableCollection<ImageArchive>, ISupportIncrementalLoading
    //{
    //    private readonly IBingWallpaperService _bingWallpaperService;

    //    public WallpaperCollection(IBingWallpaperService bingWallpaperService)
    //    {
    //        _bingWallpaperService = bingWallpaperService;
    //    }

    //    public bool HasMoreItems
    //    {
    //        get
    //        {
    //            return _loading == false;
    //        }
    //    }

    //    private bool _loading;

    //    public async Task<LoadMoreItemsResult> LoadMoreWallpaperInformation(int count)
    //    {
    //        uint loadCount = 0;
    //        if (_loading == false)
    //        {
    //            _loading = true;

    //            ImageArchiveCollection imageArchiveCollection = await _bingWallpaperService.GetWallpaperInformationsAsync(Count, count, CultureInfo.CurrentCulture);
    //            if (imageArchiveCollection != null)
    //            {
    //                ImageArchive[] imageArchives = imageArchiveCollection.Images;
    //                foreach (var imageArchive in imageArchives)
    //                {
    //                    if (this.Any(temp => temp.UrlBase == imageArchive.UrlBase) == false)
    //                    {
    //                        Add(imageArchive);
    //                        loadCount++;
    //                    }
    //                }
    //            }

    //            _loading = false;
    //        }
    //        if (loadCount == 0)
    //        {
    //            _loading = true;
    //        }
    //        return new LoadMoreItemsResult()
    //        {
    //            Count = loadCount
    //        };
    //    }

    //    public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
    //    {
    //        return LoadMoreWallpaperInformation((int)count).AsAsyncOperation();
    //    }
    //}
}