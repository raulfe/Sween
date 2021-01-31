using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using Sween.Models;
using Sween.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class PasswordViewModel:BaseViewModel
    {
        #region Attributes
        private User user;
        #endregion

        #region Properties
        public User User { get { return user; } set { SetValue(ref user, value); } }
        #endregion

        #region Constructor
        public PasswordViewModel(User User)
        {
            this.User = User;
            this.User.Email = "email@email.com";
            this.User.ImageURL = "https://sweenblobs.blob.core.windows.net/ImageDefault.jpg";
            
        }
        #endregion

        #region Commands
        public ICommand Next4Command
        {
            get
            {
                return new RelayCommand(Next);
            }
        }

        public ICommand Back4Command
        {
            get
            {
                return new RelayCommand(Back);
            }
        }
        #endregion

        #region Functions
        private async void Next()
        {
            
            UserDialogs.Instance.ShowLoading("Espere");
            var data = await ServiceWebApi.InsertUser(this.User);
            if(data == null)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("Error","Tu registro no fue aceptado","Aceptar");
                this.User = null;
            }
            UserDialogs.Instance.HideLoading();
            await App.Current.MainPage.DisplayAlert("Bienvenido", $"Es momento de ingresar {data.Name}", "Aceptar");
            MainViewModels.GetInstance().Login = new LoginViewModel();
            this.User = null;
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async void Back()
        {
            MainViewModels.GetInstance().User = new UsuarioViewModel(this.User);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
