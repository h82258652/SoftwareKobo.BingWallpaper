using Windows.ApplicationModel.Activation;

namespace SoftwareKobo.BingWallpaper.Interfaces
{
    public interface IContinueFileSave
    {
        void ContinueFileSave(FileSavePickerContinuationEventArgs args);
    }
}