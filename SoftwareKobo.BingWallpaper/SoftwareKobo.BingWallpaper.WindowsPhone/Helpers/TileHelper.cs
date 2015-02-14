using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using System;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public static class TileHelper
    {
        public static async void RegisterBackgroundTileUpdateTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == "TileTask")
                {
                    return;
                }
            }

            var access = await BackgroundExecutionManager.RequestAccessAsync();

            if (access != BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
            {
                return;
            }

            var builder = new BackgroundTaskBuilder();

            builder.Name = "TileTask";
            builder.TaskEntryPoint = "SoftwareKobo.BingWallpaper.WindowsPhone.BackgroundTask.UpdateTileTask";
            builder.SetTrigger(new TimeTrigger(90, false));

            BackgroundTaskRegistration registration = builder.Register();
        }

        public static void UpdateTile(ImageArchive image)
        {
            TileNotification tile = new TileNotification(CreateTileTemplate(image));
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tile);
        }

        private static XmlDocument CreateTileTemplate(ImageArchive imageArchive)
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