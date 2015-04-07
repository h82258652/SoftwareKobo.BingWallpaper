using Windows.ApplicationModel.Resources;

namespace SoftwareKobo.BingWallpaper.Helpers
{
    public static class ResourcesHelper
    {
        private readonly static ResourceLoader Loader = new ResourceLoader();

        public static string ChooseEveryTime
        {
            get
            {
                return Loader.GetString("ChooseEveryTime");
            }
        }

        public static string Default
        {
            get
            {
                return Loader.GetString("Default");
            }
        }

        public static string NetworkError
        {
            get
            {
                return Loader.GetString("NetworkError");
            }
        }

        public static string NowLoading
        {
            get
            {
                return Loader.GetString("NowLoading");
            }
        }

        public static string PictureLibrary
        {
            get
            {
                return Loader.GetString("PictureLibrary");
            }
        }

        public static string SaveSuccess
        {
            get
            {
                return Loader.GetString("SaveSuccess");
            }
        }

        public static string SaveFailed
        {
            get
            {
                return Loader.GetString("SaveFailed");
            }
        }

        public static string ShareSuccess
        {
            get
            {
                return Loader.GetString("ShareSuccess");
            }
        }

        public static string ShareFailed
        {
            get
            {
                return Loader.GetString("ShareFailed");
            }
        }

        public static string SavedPictures
        {
            get
            {
                return Loader.GetString("SavedPictures");
            }
        }

        public static string Germany
        {
            get
            {
                return Loader.GetString("Germany");
            }
        }

        public static string Australia
        {
            get
            {
                return Loader.GetString("Australia");
            }
        }

        public static string Canada
        {
            get
            {
                return Loader.GetString("Canada");
            }
        }

        public static string NewZealand
        {
            get
            {
                return Loader.GetString("NewZealand");
            }
        }

        public static string England
        {
            get
            {
                return Loader.GetString("England");
            }
        }

        public static string America
        {
            get
            {
                return Loader.GetString("America");
            }
        }

        public static string Japan
        {
            get
            {
                return Loader.GetString("Japan");
            }
        }

        public static string China
        {
            get
            {
                return Loader.GetString("China");
            }
        }
    }
}