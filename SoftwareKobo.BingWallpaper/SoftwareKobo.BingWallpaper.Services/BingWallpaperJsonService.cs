using Newtonsoft.Json;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.Services
{
    public class BingWallpaperJsonService : IBingWallpaperService
    {
        private const string LINKTEMPLATE = @"http://www.bing.com/hpimagearchive.aspx?format=js&idx={0}&n={1}&mkt={2}";

        public async Task<ImageArchiveCollection> GetWallpaperInformationsAsync(int daysAgo, int count, CultureInfo area)
        {
            string url = string.Format(CultureInfo.InvariantCulture, LINKTEMPLATE, daysAgo, count, area.Name);
            Uri uri = new Uri(url, UriKind.Absolute);
            string json;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(area.Name);
                json = await client.GetStringAsync(uri);
            }
            ImageArchiveCollection imageArchiveCollection = JsonConvert.DeserializeObject<ImageArchiveCollection>(json);
            return imageArchiveCollection;
        }
    }
}