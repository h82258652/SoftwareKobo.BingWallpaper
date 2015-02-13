using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.Services.Interfaces;
using System.Globalization;
using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.BackgroundTask
{
    public sealed class UpdateTileTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _deferral;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            UpdateTile();
        }

        private async void UpdateTile()
        {
            try
            {
                IBingWallpaperService service = new BingWallpaperJsonService();
                ImageArchiveCollection imageArchiveCollection = await service.GetWallpaperInformationsAsync(0, 1, CultureInfo.CurrentCulture);
                ImageArchive image = imageArchiveCollection.Images.FirstOrDefault();

                TileNotification tile = new TileNotification(CreateTileTemplate(image));
                TileUpdateManager.CreateTileUpdaterForApplication().Update(tile);
            }
            finally
            {
                _deferral.Complete();
            }
        }

        private XmlDocument CreateTileTemplate(ImageArchive imageArchive)
        {
            string tileText = imageArchive.Messages[0].Text;

            XmlDocument document = new XmlDocument();

            // tile 根节点。
            XmlElement tile = document.CreateElement("tile");
            document.AppendChild(tile);

            // visual 元素。
            XmlElement visual = document.CreateElement("visual");
            visual.SetAttribute("version", "2");
            tile.AppendChild(visual);

            // 150x150
            {
                // binding
                XmlElement binding = document.CreateElement("binding");
                binding.SetAttribute("template", "TileSquare150x150PeekImageAndText04");
                binding.SetAttribute("fallback", "TileSquarePeekImageAndText04");
                visual.AppendChild(binding);

                // image
                XmlElement image = document.CreateElement("image");
                image.SetAttribute("id", "1");
                image.SetAttribute("src", imageArchive.GetUrlWithSize(WallpaperSize._150x150));
                image.SetAttribute("alt", "");
                binding.AppendChild(image);

                // text
                XmlElement text = document.CreateElement("text");
                text.SetAttribute("id", "1");
                text.AppendChild(document.CreateTextNode(tileText));
                binding.AppendChild(text);
            }

            // 310x150
            {
                // binding
                XmlElement binding = document.CreateElement("binding");
                binding.SetAttribute("template", "TileWide310x150PeekImageAndText01");
                binding.SetAttribute("fallback", "TileWidePeekImageAndText01");
                visual.AppendChild(binding);

                // image
                XmlElement image = document.CreateElement("image");
                image.SetAttribute("id", "1");
                image.SetAttribute("src", imageArchive.GetUrlWithSize(WallpaperSize._310x150));
                image.SetAttribute("alt", "");
                binding.AppendChild(image);

                // text
                XmlElement text = document.CreateElement("text");
                text.SetAttribute("id", "1");
                text.AppendChild(document.CreateTextNode(tileText));
                binding.AppendChild(text);
            }

            return document;
        }
    }
}