using Newtonsoft.Json;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.Services
{
    public class BingWallpaperJsonProxyService : IBingWallpaperService
    {
        private const string LINKTEMPLATE = @"https://app-hzf.rhcloud.com/bingwallpaper/get?format=js&idx={0}&n={1}&mkt={2}";

        public async Task<ImageArchiveCollection> GetWallpaperInformationsAsync(int daysAgo, int count, string area)
        {
            if (string.Equals(area, "zh-CN", StringComparison.OrdinalIgnoreCase))
            {
                return await new BingWallpaperJsonService().GetWallpaperInformationsAsync(daysAgo, count, area);
            }
            else
            {
                string url = string.Format(CultureInfo.InvariantCulture, LINKTEMPLATE, daysAgo, count, area);
                Uri uri = new Uri(url, UriKind.Absolute);
                string json;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(area);
                    json = await client.GetStringAsync(uri);
                }
                ImageArchiveCollection imageArchiveCollection = JsonConvert.DeserializeObject<ImageArchiveCollection>(json);
                return imageArchiveCollection;
            }
        }
    }
}