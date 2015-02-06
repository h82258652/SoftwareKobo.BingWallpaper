using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareKobo.BingWallpaper.Model
{
    [JsonObject]
    public class ToolTip
    {
        [JsonProperty("loading")]
        public string Loading
        {
            get;
            set;
        }

        [JsonProperty("previous")]
        public string Previous
        {
            get;
            set;
        }

        [JsonProperty("next")]
        public string Next
        {
            get;
            set;
        }

        public string walle
        {
            get;
            set;
        }

        public string walls
        {
            get;
            set;
        }
    }
}