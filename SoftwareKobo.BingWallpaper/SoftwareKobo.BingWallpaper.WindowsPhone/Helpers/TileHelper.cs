using SoftwareKobo.BingWallpaper.Model;
using SoftwareKobo.BingWallpaper.Services;
using SoftwareKobo.BingWallpaper.WindowsPhone.BackgroundTask;
using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public static class TileHelper
    {
        /// <summary>
        /// 注册后台更新主磁贴任务。
        /// </summary>
        public static async void RegisterBackgroundTileUpdateTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == "TileTask")
                {
                    // 已经注册后台任务。
                    return;
                }
            }

            var access = await BackgroundExecutionManager.RequestAccessAsync();

            if (access != BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
            {
                // 没有权限。
                return;
            }

            var builder = new BackgroundTaskBuilder();

            builder.Name = "TileTask";
            builder.TaskEntryPoint = "SoftwareKobo.BingWallpaper.WindowsPhone.BackgroundTask.UpdateTileTask";
            // 每 90 分钟触发一次。
            builder.SetTrigger(new TimeTrigger(90, false));

            BackgroundTaskRegistration registration = builder.Register();
        }

        /// <summary>
        /// 根据壁纸信息更新磁贴。
        /// </summary>
        /// <param name="image"></param>
        public static void UpdateTile(ImageArchive image)
        {
            string tileText = image.Messages[0].Text;
            string _150x150url = image.GetUrlWithSize(WallpaperSize._150x150);
            string _310x150url = image.GetUrlWithSize(WallpaperSize._310x150);

            TileNotification tile = new TileNotification(TileTemplateHelper.CreateTileTemplate(tileText, _150x150url, _310x150url));
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tile);
        }
    }
}