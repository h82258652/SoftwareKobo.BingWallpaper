using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareKobo.BingWallpaper.Model
{
    [JsonObject]
    public class Hotspot
    {
        [JsonProperty("desc")]
        public string Description
        {
            get;
            set;
        }

        [JsonProperty("link")]
        public string Link
        {
            get;
            set;
        }

        [JsonProperty("query")]
        public string Query
        {
            get;
            set;
        }

        [JsonProperty("locx")]
        public int LocationX
        {
            get;
            set;
        }

        [JsonProperty("locy")]
        public int LocationY
        {
            get;
            set;
        }
    }
}