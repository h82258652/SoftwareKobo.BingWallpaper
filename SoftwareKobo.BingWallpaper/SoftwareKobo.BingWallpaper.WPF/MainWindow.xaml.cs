using System.Threading.Tasks;
using MahApps.Metro.Controls;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.WPF.Controls;
using SoftwareKobo.BingWallpaper.WPF.ViewModels;
using SoftwareKobo.BingWallpaper.WPF.Views;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace SoftwareKobo.BingWallpaper.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ScrollBar _bottomBar;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public MainWindowViewModel ViewModel
        {
            get
            {
                return (MainWindowViewModel)DataContext;
            }
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[0] as Flyout;
            if (flyout == null)
            {
                return;
            }
            flyout.IsOpen = !flyout.IsOpen;
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ListView listView = (ListView) sender;
            ScrollViewer scroll = VisualTreeHelperEx.FindDescendantByType<ScrollViewer>(listView);
            if (scroll == null)
            {
                return;
            }

            // 鼠标横向滚动。
            listView.AddHandler(MouseWheelEvent, new MouseWheelEventHandler((mouseWheelSender, mouseWheelEventArgs) =>
            {
                var delta = mouseWheelEventArgs.Delta;
                if (delta > 0)
                {
                    scroll.LineLeft();
                }
                else
                {
                    scroll.LineRight();
                }
            }), true);


           var bar = scroll.FindVisualChildren<ScrollBar>().ElementAt(2);
           bar.ValueChanged += bar_ValueChanged;
            _bottomBar = bar;
        }

        void bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

                    var bar = (ScrollBar)sender;
                    if ((e.NewValue / bar.Maximum) > 0.8)
                    {
                        ViewModel.LoadCommand.Execute(null);
                    }
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_bottomBar!=null)
            {
                if (_bottomBar.Visibility == Visibility.Collapsed)
                {
                this.Dispatcher.Invoke(() => ViewModel.LoadCommand.Execute(null));
                }
                //Task.Factory.StartNew(() =>
                //{
                //    while (_bottomBar.Visibility == Visibility.Collapsed)
                //    {
                        
                //    }
                //});
            }
        }
        
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //WallpaperDetailWindow detailWindow=new WallpaperDetailWindow();
            ////detailWindow.ViewModel.ImageArchive = (ImageArchive)((ListView) sender).SelectedItem;
            ////detailWindow.Owner = this;
            //detailWindow.Show();
        }

        private void WallpaperThumbControl_OnClick(object sender, RoutedEventArgs e)
        {
            WallpaperDetailWindow w = new WallpaperDetailWindow();
            var imageArchive = ((WallpaperThumbControl) sender).DataContext as ImageArchive;
            w.ViewModel.SetImageArchive(imageArchive);
            w.Show();
        }
    }
}