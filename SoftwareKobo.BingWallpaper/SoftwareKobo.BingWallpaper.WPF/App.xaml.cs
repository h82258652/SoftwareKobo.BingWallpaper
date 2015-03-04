using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace SoftwareKobo.BingWallpaper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            //Thread.CurrentThread.CurrentCulture=new CultureInfo("en-us");
            //Thread.CurrentThread.CurrentUICulture=new CultureInfo("en-us");
            DispatcherHelper.Initialize();
        }
    }
}
