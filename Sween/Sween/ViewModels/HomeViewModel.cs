using GalaSoft.MvvmLight.Command;
using Sween.Services;
using Sween.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Constructor
        public HomeViewModel()
        {
            var url = new Uri(App.User.ImageURLSAS);
            Image = url;
        }
        #endregion

        #region Attributes
        private Uri image;
        #endregion

        #region Properties
        public Uri Image { get { return image; } set { SetValue(ref image, value); } }
        #endregion

        #region Commands
        public ICommand PhotoCommand
        {
            get
            {
                return new RelayCommand(AddPhoto);
            }
        }
        #endregion

        #region Functions

        private async void AddPhoto()
        {
            try
            {
                var action = await App.Current.MainPage.DisplayActionSheet("Foto de perfil", "Cancelar", null, "Usar cámara", "Seleccionar de galería");
                bool camera = action.Contains("Usar cámara");
                var file = await ServiceImage.TakePicture(camera);
                await App.Current.MainPage.Navigation.PushAsync(new PreImageView(file), true);
            }catch(Exception ex)
            {
                var msgError = ex.Message;
            }
        }
        #endregion
    }
}
