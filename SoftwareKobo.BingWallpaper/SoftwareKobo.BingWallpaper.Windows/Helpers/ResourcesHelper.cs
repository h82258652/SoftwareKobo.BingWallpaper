using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace SoftwareKobo.BingWallpaper.Helpers
{
  public static  class ResourcesHelper
    {
      private readonly static ResourceLoader Loader=new ResourceLoader();

      public static string Default
      {
          get { return Loader.GetString("Default"); }
      }

      public static string PictureLibrary
      {
          get { return Loader.GetString("PictureLibrary"); }
      }
    }
}
