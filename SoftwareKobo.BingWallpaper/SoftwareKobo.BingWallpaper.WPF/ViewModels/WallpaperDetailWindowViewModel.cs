using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WPF.Datas;
using SoftwareKobo.BingWallpaper.WPF.Properties;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SoftwareKobo.BingWallpaper.WPF.ViewModels
{
    public class WallpaperDetailWindowViewModel : ViewModelBase
    {
        private ImageArchive _imageArchive;

        private bool _isLoading;

        private ICommand _saveCommand;

        private BitmapSource _wallpaper;

        private double _wallpaperHeight;

        private double _wallpaperWidth;

        public WallpaperDetailWindowViewModel()
        {
            Global.LoadedImageArchives.CollectionChanged += (sender, e) =>
            {
                RaisePropertyChanged(() => PreviousCommand);
                RaisePropertyChanged(() => NextCommand);
            };
        }

        public ImageArchive ImageArchive
        {
            get
            {
                return _imageArchive;
            }
            set
            {
                _imageArchive = value;
                RaisePropertyChanged(() => ImageArchive);
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
                RaisePropertyChanged(() => PreviousCommand);
                RaisePropertyChanged(() => NextCommand);
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand(() =>
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.FileName = ImageArchive.Messages[0].Text;
                        dialog.Filter = string.Format("{0}(*.jpg)|*.jpg|{1}(*.*)|*.*", Resources.ImageFiles, Resources.AllFiles);
                        dialog.OverwritePrompt = true;
                        dialog.AddExtension = true;

                        if (dialog.ShowDialog() == true)
                        {
                            string savePath = dialog.FileName;
                            if (Wallpaper.IsDownloading)
                            {
                                // 图片控件没有下载完。
                                using (WebClient client = new WebClient())
                                {
                                    client.DownloadFileAsync(new Uri(ImageArchive.GetUrlWithSize(Datas.Settings.WallpaperSize)), savePath);
                                }
                            }
                            else
                            {
                                // 图片控件下载完毕，直接从控件源中提取数据。
                                JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
                                jpgEncoder.Frames.Add(BitmapFrame.Create(Wallpaper));
                                using (FileStream stream = File.Open(savePath, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    jpgEncoder.Save(stream);
                                }
                            }
                        }
                    });
                return _saveCommand;
            }
        }

        private ICommand _nextCommand;

        public ICommand NextCommand
        {
            get
            {
                _nextCommand = _nextCommand ?? new RelayCommand(async () =>
                {
                    var index = Global.LoadedImageArchives.IndexOf(ImageArchive);
                    var nextImageArchive = Global.LoadedImageArchives.ElementAtOrDefault(index + 1);
                    if (nextImageArchive != null)
                    {
                        SetImageArchive(nextImageArchive);
                        await Global.LoadMore(1);
                    }
                }, () =>
                {
                    var index = Global.LoadedImageArchives.IndexOf(ImageArchive);
                    if (index == Global.LoadedImageArchives.Count - 1)
                    {
                        return false;
                    }
                    return true;
                });
                return _nextCommand;
            }
        }

        private ICommand _previousCommand;

        public ICommand PreviousCommand
        {
            get
            {
                _previousCommand = _previousCommand ?? new RelayCommand(() =>
                {
                    var index = Global.LoadedImageArchives.IndexOf(ImageArchive);
                    var previousImageArchive = Global.LoadedImageArchives.ElementAtOrDefault(index - 1);
                    if (previousImageArchive != null)
                    {
                        SetImageArchive(previousImageArchive);
                    }
                }, () =>
                {
                    var index = Global.LoadedImageArchives.IndexOf(ImageArchive);
                    if (index == 0)
                    {
                        return false;
                    }
                    return true;
                });
                return _previousCommand;
            }
        }

        public BitmapSource Wallpaper
        {
            get
            {
                return _wallpaper;
            }
            set
            {
                _wallpaper = value;
                RaisePropertyChanged(() => Wallpaper);
            }
        }

        public double WallpaperHeight
        {
            get
            {
                return _wallpaperHeight;
            }
            set
            {
                _wallpaperHeight = value;
                RaisePropertyChanged(() => WallpaperHeight);
            }
        }

        public double WallpaperWidth
        {
            get
            {
                return _wallpaperWidth;
            }
            set
            {
                _wallpaperWidth = value;
                RaisePropertyChanged(() => WallpaperWidth);
            }
        }

        public void SetImageArchive(ImageArchive imageArchive)
        {
            ImageArchive = imageArchive;

            var wallpaperSize = Datas.Settings.WallpaperSize;

            WallpaperWidth = wallpaperSize.GetWidth();
            WallpaperHeight = wallpaperSize.GetHeight();

            IsLoading = true;

            string url = imageArchive.GetUrlWithSize(wallpaperSize);
            Uri uri = new Uri(url, UriKind.Absolute);
            WebClient client = new WebClient();
            client.DownloadDataAsync(uri);
            client.DownloadDataCompleted += Wallpaper_DownloadCompleted;
        }

        private void Wallpaper_DownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            MemoryStream stream = new MemoryStream(e.Result);
            JpegBitmapDecoder jpgDecoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            Wallpaper = jpgDecoder.Frames[0];

            IsLoading = false;
        }

        private async void Wallpaper_DownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            if (e.Progress < 100)
            {
                IsLoading = true;
            }
            else
            {
                IsLoading = false;
            }
        }

        private ObservableCollection<ImageArchive> MainWindowImageArchives()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null)
            {
                return null;
            }
            return null;
        }
    }
}