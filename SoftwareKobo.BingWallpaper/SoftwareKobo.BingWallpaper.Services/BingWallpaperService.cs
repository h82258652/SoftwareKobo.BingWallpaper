using Newtonsoft.Json;
using SoftwareKobo.BingWallpaper.Model;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftwareKobo.BingWallpaper.Services
{
    public class BingWallpaperService
    {
        private const string LINKTEMPLATE = @"http://www.bing.com/hpimagearchive.aspx?format={0}&idx={1}&n={2}&mkt={3}";

        public async Task<ImageArchiveCollection> GetWallpaperInformations(Format format, int daysAgo, int count, CultureInfo area)
        {
            switch (format)
            {
                case Format.Xml:
                    return await GetWallpaperInformationsByXml(daysAgo, count, area);

                case Format.Json:
                    return await GetWallpaperInformationsByJson(daysAgo, count, area);

                default:
                    throw new ArgumentException("invalid format", "format");
            }
        }

#pragma warning disable
        private async Task<ImageArchiveCollection> GetWallpaperInformationsByXml(int daysAgo, int count, CultureInfo area)
        {
            throw new NotImplementedException();
        }
#pragma warning restore

        private async Task<ImageArchiveCollection> GetWallpaperInformationsByJson(int daysAgo, int count, CultureInfo area)
        {
            string url = string.Format(CultureInfo.InvariantCulture, LINKTEMPLATE, "js", daysAgo, count, area.Name);
            Uri uri = new Uri(url, UriKind.Absolute);
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = await client.GetStringAsync(uri);
            }
            var imageArchiveCollection = JsonConvert.DeserializeObject<ImageArchiveCollection>(json);
            return imageArchiveCollection;
        }
    }
}