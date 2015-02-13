using Windows.ApplicationModel.Activation;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Interfaces
{
    public interface IContinueFileSave
    {
        void ContinueFileSave(FileSavePickerContinuationEventArgs args);
    }
}