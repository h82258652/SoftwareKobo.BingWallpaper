using GalaSoft.MvvmLight;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;

namespace SoftwareKobo.BingWallpaper.WPF.Datas
{
    public static class Settings
    {
        public static WallpaperSize WallpaperSize
        {
            get
            {
                string value = Read("WallpaperSize");
                WallpaperSize wallpaperSize;
                if (value != null)
                {
                    if (Enum.TryParse(value, out wallpaperSize))
                    {
                        return wallpaperSize;
                    }
                }
                wallpaperSize = WallpaperSizeHelper.GetDefaultsSize();
                return wallpaperSize;
            }
            set
            {
                Write("WallpaperSize", value.ToString());
            }
        }

        private static string Read(string key)
        {
            var keyValues = ReadAllKeyValues();
            if (keyValues.ContainsKey(key))
            {
                return keyValues[key];
            }
            else
            {
                return null;
            }
        }

        private static void Write(string key, string value)
        {
            var keyValues = ReadAllKeyValues();
            if (keyValues.ContainsKey(key))
            {
                keyValues[key] = value;
            }
            else
            {
                keyValues.Add(key, value);
            }
            WriteAllKeyValues(keyValues);
        }

        private static string ReadAllText()
        {
            // Don't read in design mode.
            if (ViewModelBase.IsInDesignModeStatic)
            {
                return string.Empty;
            }
            using (IsolatedStorageFile storeFile = IsolatedStorageFile.GetUserStoreForDomain())
            {
                using (IsolatedStorageFileStream settings = storeFile.OpenFile("settings.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (TextReader reader = new StreamReader(settings))
                    {
                        string text = reader.ReadToEnd();
                        return text;
                    }
                }
            }
        }

        private static void WriteAllText(string text)
        {
            // Don't write in design mode.
            if (ViewModelBase.IsInDesignModeStatic)
            {
                return;
            }
            using (IsolatedStorageFile storeFile = IsolatedStorageFile.GetUserStoreForDomain())
            {
                using (IsolatedStorageFileStream settings = storeFile.OpenFile("settings.txt", FileMode.Create, FileAccess.ReadWrite))
                {
                    using (TextWriter writer = new StreamWriter(settings))
                    {
                        writer.Write(text);
                    }
                }
            }
        }

        private static IEnumerable<string> ReadAllLines()
        {
            string text = ReadAllText();
            return text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void WriteAllLines(params string[] lines)
        {
            string text = string.Join(Environment.NewLine, lines);
            WriteAllText(text);
        }

        private static IDictionary<string, string> ReadAllKeyValues()
        {
            IEnumerable<string> lines = ReadAllLines();
            IDictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                string[] temp = line.Split('=');
                if (temp.Length == 2)
                {
                    string key = temp[0].Trim();
                    string value = temp[1].Trim();
                    dict.Add(key, value);
                }
            }
            return dict;
        }

        private static void WriteAllKeyValues(IDictionary<string, string> keyValues)
        {
            List<string> lines = new List<string>();
            foreach (KeyValuePair<string, string> keyValue in keyValues)
            {
                lines.Add(string.Format(CultureInfo.InvariantCulture, "{0}={1}", keyValue.Key, keyValue.Value));
            }
            WriteAllLines(lines.ToArray());
        }
    }
}