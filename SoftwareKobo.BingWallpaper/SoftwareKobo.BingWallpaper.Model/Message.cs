using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareKobo.BingWallpaper.Model
{
    [JsonObject]
    public class Message
    {
        [JsonProperty("title")]
        public string Title
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

        [JsonProperty("text")]
        public string Text
        {
            get;
            set;
        }
    }
}