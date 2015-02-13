using System;
using Windows.ApplicationModel.Background;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Helpers
{
    public class BackgroundTileTaskHelper
    {
        public static async void Register()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == "TileTask")
                {
                    return;
                }
            }

            var access = await BackgroundExecutionManager.RequestAccessAsync();

            if (access != BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
            {
                return;
            }

            var builder = new BackgroundTaskBuilder();

            builder.Name = "TileTask";
            builder.TaskEntryPoint = "SoftwareKobo.BingWallpaper.WindowsPhone.BackgroundTask.UpdateTileTask";
            builder.SetTrigger(new TimeTrigger(90, false));

            BackgroundTaskRegistration registration = builder.Register();
        }
    }
}