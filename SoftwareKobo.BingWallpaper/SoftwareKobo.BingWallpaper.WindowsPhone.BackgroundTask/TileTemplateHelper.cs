using System;
using Windows.Data.Xml.Dom;

namespace SoftwareKobo.BingWallpaper.BackgroundTask
{
    public static class TileTemplateHelper
    {
        /// <summary>
        /// 获取磁贴模板。
        /// </summary>
        /// <param name="tileText">磁贴文字。</param>
        /// <param name="_150x150url">150x150 大小时，磁贴显示的图片路径。</param>
        /// <param name="_310x150url">310x150 大小时，磁贴显示的图片路径。</param>
        /// <returns>磁贴模板。</returns>
        /// <exception cref="ArgumentNullException">150x150 的路径为 null。</exception>
        /// <exception cref="ArgumentNullException">310x150 的路径为 null。</exception>
        /// <exception cref="ArgumentException">310x150 的路径为空字符串。</exception>
        /// <exception cref="ArgumentException">310x150 的路径为空字符串。</exception>
// ReSharper disable InconsistentNaming
        public static XmlDocument CreateTileTemplate(string tileText, string _150x150url, string _310x150url)
// ReSharper restore InconsistentNaming
        {
            if (_150x150url == null)
            {
                throw new ArgumentNullException("_150x150url");
            }
            if (_310x150url == null)
            {
                throw new ArgumentNullException("_310x150url");
            }
            if (_150x150url.Length <= 0)
            {
                throw new ArgumentException("image url can not be empty.", "_150x150url");
            }
            if (_310x150url.Length <= 0)
            {
                throw new ArgumentException("image url can not be empty.", "_150x150url");
            }

            tileText = tileText ?? string.Empty;

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
                image.SetAttribute("src", _150x150url);
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
                image.SetAttribute("src", _310x150url);
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