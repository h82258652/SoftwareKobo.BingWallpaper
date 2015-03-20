using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.Services
{
    [Obsolete]
    public class BingWallpaperRssService : IBingWallpaperService
    {
        [Obsolete]
        public Task<ImageArchiveCollection> GetWallpaperInformationsAsync(int daysAgo, int count, string area)
        {
            throw new NotImplementedException();
        }
    }
}