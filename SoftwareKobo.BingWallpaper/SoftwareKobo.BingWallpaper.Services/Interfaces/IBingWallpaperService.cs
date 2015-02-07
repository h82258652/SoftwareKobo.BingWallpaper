using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareKobo.BingWallpaper.Model;

namespace SoftwareKobo.BingWallpaper.Services.Interfaces
{
    public interface IBingWallpaperService
    {
        Task<ImageArchiveCollection> GetWallpaperInformationsAsync(int daysAgo, int count, CultureInfo area);
    }
}
