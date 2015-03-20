using SoftwareKobo.BingWallpaper.Model;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.Services.Interfaces
{
    public interface IBingWallpaperService
    {
        Task<ImageArchiveCollection> GetWallpaperInformationsAsync(int daysAgo, int count, string area);
    }
}