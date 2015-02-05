using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareKobo.BingWallpaper.Model
{
    [JsonObject]
    public class ImageArchiveCollection
    {
        [JsonProperty("images")]
        public ImageArchive[] Images
        {
            get;
            set;
        }

        [JsonProperty("tooltips")]
        public ToolTip ToolTip
        {
            get;
            set;
        }
    }
}