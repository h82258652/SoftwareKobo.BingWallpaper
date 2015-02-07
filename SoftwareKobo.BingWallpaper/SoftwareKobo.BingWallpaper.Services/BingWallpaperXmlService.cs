using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;

namespace SoftwareKobo.BingWallpaper.Services
{
    public class BingWallpaperXmlService:IBingWallpaperService
    {
        public Task<ImageArchiveCollection> GetWallpaperInformationsAsync(int daysAgo, int count, System.Globalization.CultureInfo area)
        {
            throw new NotImplementedException();
        }
    }
}
