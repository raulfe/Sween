using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using Sween.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string nick;
        private string password;
        #endregion

        #region Properties
        public string Nick
        {
            get { return nick; }
            set { SetValue(ref nick, value); }
        }
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public ICommand CreateCommand
        {
            get
            {
                return new RelayCommand(Create);
            }
        }
        #endregion

        #region Functions
        private async void  Create()
        {
            UserDialogs.Instance.ShowLoading("Welcome");
            Nick = string.Empty;
            Password = string.Empty;
            MainViewModels.GetInstance().Create = new CreateViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new CreatePage(), true);
            UserDialogs.Instance.HideLoading();
        }

        private async void Login()
        {

        }
        #endregion
    }
}
