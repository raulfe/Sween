using GalaSoft.MvvmLight.Command;
using Sween.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class UsuarioViewModel:BaseViewModel
    {
        #region Attributes

        #endregion

        #region Propeties

        #endregion

        #region Constructor

        #endregion

        #region Commands
        public ICommand Next3Command
        {
            get
            {
                return new RelayCommand(Next);
            }
        }

        public ICommand Back3Command
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
            MainViewModels.GetInstance().Pass = new PasswordViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new PasswordPage(), true);
        }

        private async void Back()
        {
            MainViewModels.GetInstance().Movil = new MovilViewModel();
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
