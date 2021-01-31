using Acr.UserDialogs;
using Plugin.Media.Abstractions;
using Sween.Services;
using Sween.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sween.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreImageView : ContentPage
    {
        MemoryStream stream;
        public PreImageView(MediaFile file)
        {
            InitializeComponent();
            EdImg.Source = ImageSource.FromStream(() =>
             {
                 var stream = file.GetStream();
                 this.stream = new MemoryStream();
                 stream.CopyTo(this.stream);
                 stream.Seek(0, SeekOrigin.Begin);
                 file.Dispose();
                 return stream;
             });
        }

        private void EdImg_ImageSaving(object sender, Syncfusion.SfImageEditor.XForms.ImageSavingEventArgs args)
        {
            var st = args.Stream;
            stream = (MemoryStream)st;
            Save();
        }

        private async void Save()
        {
            string x = DateTime.Now.ToString("yyyy:MM:dd:HH:mm:ss");
            UserDialogs.Instance.ShowLoading("Espere");
            stream?.Seek(0, SeekOrigin.Begin);
            await ServiceWebApi.UpdateUser(App.User, stream, x);
            App.User = await ServiceWebApi.GetUser(App.User.IdUser.Value, x);
            UserDialogs.Instance.HideLoading();
            MainViewModels.GetInstance().Home = new HomeViewModel();
            await App.Current.MainPage.DisplayAlert("Información", "Perfil actualizado", "Aceptar");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}