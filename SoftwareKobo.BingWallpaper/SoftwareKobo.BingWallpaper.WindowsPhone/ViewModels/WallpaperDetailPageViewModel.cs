﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.Datas;
using SoftwareKobo.BingWallpaper.WindowsPhone.Helpers;
using SoftwareKobo.BingWallpaper.WindowsPhone.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.ViewModels
{
    public class WallpaperDetailPageViewModel : ViewModelBase, IContinueFileSave
    {
        private RelayCommand _saveCommand;

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

        private ImageArchive _imageArchive;

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

        public string WallpaperUrl
        {
            get
            {
                return ImageArchive.GetUrlWithSize(Settings.WallpaperSize);
            }
        }

        public event EventHandler OnSaveSuccess;

        public async Task SaveToPictureLibrary()
        {
            StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync(ImageArchive.Messages[0].Text + ".jpg", CreationCollisionOption.ReplaceExisting);
            await SaveFile(file);

            if (OnSaveSuccess != null)
            {
                OnSaveSuccess(this, EventArgs.Empty);
            }
        }

        public async Task SaveFile(StorageFile file)
        {
            string url = ImageArchive.GetUrlWithSize(Settings.WallpaperSize);
            Uri uri = new Uri(url, UriKind.Absolute);
            using (HttpClient client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(uri);
                await FileIO.WriteBytesAsync(file, bytes);
            }
        }

        public void SaveToChooseLocation()
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add(".jpg", new List<string>() { ".jpg" });
            savePicker.SuggestedFileName = ImageArchive.Messages[0].Text;
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.PickSaveFileAndContinue();
        }

        public async void ContinueFileSave(FileSavePickerContinuationEventArgs fileSavePickerContinuationEventArgs)
        {
            StorageFile file = fileSavePickerContinuationEventArgs.File;
            if (file != null)
            {
                await SaveFile(file);
            }
        }
    }
}