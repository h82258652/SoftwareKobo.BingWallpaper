using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareKobo.BingWallpaper.Model
{
    [JsonObject]
    public class ImageArchive
    {
        [JsonProperty("startdate")]
        public string StartDate
        {
            get;
            set;
        }

        [JsonProperty("fullstartdate")]
        public string FullStartDate
        {
            get;
            set;
        }

        [JsonProperty("enddate")]
        public string EndDate
        {
            get;
            set;
        }

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        [JsonProperty("urlbase")]
        public string UrlBase
        {
            get;
            set;
        }

        [JsonProperty("copyright")]
        public string Copyright
        {
            get;
            set;
        }

        public bool wp
        {
            get;
            set;
        }

        public string hsh
        {
            get;
            set;
        }

        public int drk
        {
            get;
            set;
        }

        public int top
        {
            get;
            set;
        }

        public int bot
        {
            get;
            set;
        }

        [JsonProperty("hs")]
        public Hotspot[] Hotspots
        {
            get;
            set;
        }

        [JsonProperty("msg")]
        public Message[] Messages
        {
            get;
            set;
        }
    }
}