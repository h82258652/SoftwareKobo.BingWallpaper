using SoftwareKobo.BingWallpaper.Datas;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.Model
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
            try
            {
                ImageArchiveCollection imageArchiveCollection = await _bingWallpaperService.GetWallpaperInformationsAsync(this.Count, count, Settings.Area);
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
            catch
            {
                return Enumerable.Empty<ImageArchive>();
            }
        }

        protected override void AddItems(IEnumerable<ImageArchive> items)
        {
            if (items != null)
            {
                foreach (ImageArchive item in items)
                {
                    if (this.Any(temp => temp.UrlBase == item.UrlBase) == false)
                    {
                        Add(item);
                    }
                }
            }
        }

        public void Reset()
        {
            ClearItems();
            this._isEnd = false;
        }
    }
}