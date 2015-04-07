using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoftwareKobo.BingWallpaper.Datas;
using SoftwareKobo.BingWallpaper.Helpers;
using SoftwareKobo.BingWallpaper.Interfaces;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace SoftwareKobo.BingWallpaper.ViewModels
{
    public class WallpaperDetailPageViewModel : ViewModelBase, IContinueFileSave
    {
        private ImageArchive _imageArchive;

        private RelayCommand _nextCommand;

        private RelayCommand _previousCommand;

        private RelayCommand _saveCommand;

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

        public RelayCommand NextCommand
        {
            get
            {
                _nextCommand = _nextCommand ?? new RelayCommand(async () =>
                {
                    int index = Global.WallpaperCollection.IndexOf(this.ImageArchive);
                    if (index < 0)
                    {
                        return;
                    }
                    if (index == Global.WallpaperCollection.Count - 1)
                    {
                        await Global.WallpaperCollection.LoadMoreItemsAsync(1);
                        index = Global.WallpaperCollection.IndexOf(this.ImageArchive);
                    }
                    if (index < Global.WallpaperCollection.Count)
                    {
                        ImageArchive forwardImageArchive = Global.WallpaperCollection.ElementAtOrDefault(index + 1);
                        if (forwardImageArchive != null)
                        {
                            this.ImageArchive = forwardImageArchive;
                            Messenger.Default.Send<ImageArchive>(forwardImageArchive);
                            this.RaisePropertyChanged(() => WallpaperUrl);
                            this.PreviousCommand.RaiseCanExecuteChanged();
                            this.NextCommand.RaiseCanExecuteChanged();
                        }
                    }
                }, () =>
                {
                    int index = Global.WallpaperCollection.IndexOf(this.ImageArchive);
                    return index > -1 && index < Global.WallpaperCollection.Count - 1;
                });
                return _nextCommand;
            }
        }

        public RelayCommand PreviousCommand
        {
            get
            {
                _previousCommand = _previousCommand ?? new RelayCommand(() =>
                {
                    int index = Global.WallpaperCollection.IndexOf(this.ImageArchive);
                    if (index > 0)
                    {
                        ImageArchive backImageArchive = Global.WallpaperCollection.ElementAtOrDefault(index - 1);
                        if (backImageArchive != null)
                        {
                            this.ImageArchive = backImageArchive;
                            Messenger.Default.Send<ImageArchive>(backImageArchive);
                            this.RaisePropertyChanged(() => WallpaperUrl);
                            this.PreviousCommand.RaiseCanExecuteChanged();
                            this.NextCommand.RaiseCanExecuteChanged();
                        }
                    }
                }, () =>
                {
                    int index = Global.WallpaperCollection.IndexOf(this.ImageArchive);
                    return index > 0;
                });
                return _previousCommand;
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand(async () =>
                {
                    string saveLocation = Settings.SaveLocation;
                    if (saveLocation == ResourcesHelper.PictureLibrary)
                    {
                        await SaveToPictureLibrary();
                    }
                    else if (saveLocation == ResourcesHelper.ChooseEveryTime)
                    {
                        SaveToChooseLocation();
                    }
                    else
                    {
                        return;
                    }
                });
                return _saveCommand;
            }
        }

        public string WallpaperUrl
        {
            get
            {
                if (IsInDesignMode)
                {
                    return null;
                }
                else
                {
                    return ImageArchive.GetUrlWithSize(Settings.WallpaperSize);
                }
            }
        }

        public async void ContinueFileSave(FileSavePickerContinuationEventArgs fileSavePickerContinuationEventArgs)
        {
            StorageFile file = fileSavePickerContinuationEventArgs.File;
            if (file != null)
            {
                await SaveFile(file);
            }
        }

        public void RaiseWallpaperUrlChanged()
        {
            RaisePropertyChanged(() => WallpaperUrl);
        }

        public async Task SaveFile(StorageFile file)
        {
            string url = ImageArchive.GetUrlWithSize(Settings.WallpaperSize);
            Uri uri = new Uri(url, UriKind.Absolute);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] bytes = await client.GetByteArrayAsync(uri);
                    await FileIO.WriteBytesAsync(file, bytes);
                }
            }
            catch (HttpRequestException)
            {
                Messenger.Default.Send("Network Error");
                return;
            }

            Messenger.Default.Send("Save Success");
        }

        public void SaveToChooseLocation()
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add(".jpg", new List<string>() { ".jpg" });
            savePicker.SuggestedFileName = ImageArchive.GetTitle();
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.PickSaveFileAndContinue();
        }

        public async Task SaveToPictureLibrary()
        {
            try
            {
                StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync(ImageArchive.GetTitle() + ".jpg", CreationCollisionOption.ReplaceExisting);
                await SaveFile(file);
            }
            catch
            {
                Messenger.Default.Send("Save Failed");
            }
        }
    }
}