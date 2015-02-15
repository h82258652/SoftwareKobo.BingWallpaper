using Windows.ApplicationModel.Resources;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
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
    }
}