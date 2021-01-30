using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class PasswordViewModel:BaseViewModel
    {
        #region Attributes

        #endregion

        #region Properties

        #endregion

        #region Constructor

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
            MainViewModels.GetInstance().Login = new LoginViewModel();
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async void Back()
        {
            MainViewModels.GetInstance().User = new UsuarioViewModel();
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
