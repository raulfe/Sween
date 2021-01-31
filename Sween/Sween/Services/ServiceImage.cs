using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;

namespace Sween.Services
{
    public class ServiceImage
    {
        public static async Task<MediaFile> TakePicture(bool useCamera)
        {
            await CrossMedia.Current.Initialize();
            try { 
            if (useCamera)
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    return null;
            var file = useCamera ? await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { Directory = "User", Name = $"{DateTime.UtcNow}.jpg" }) : await CrossMedia.Current.PickPhotoAsync();
            return file;
            }catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error","Intenta de nuevo","Aceptar");
                return null;
            }

        }
    }
}
