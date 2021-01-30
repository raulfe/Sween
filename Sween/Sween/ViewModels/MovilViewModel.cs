using GalaSoft.MvvmLight.Command;
using Sween.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class MovilViewModel:BaseViewModel
    {
        #region Attributes

        #endregion

        #region Properties

        #endregion

        #region Constructor

        #endregion

        #region Commands
        public ICommand Next2Command
        {
            get
            {
                return new RelayCommand(Next);
            }
        }

        public ICommand Back2Command
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
            MainViewModels.GetInstance().User = new UsuarioViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new UsuarioPage(), true);
        }

        private async void Back()
        {
            MainViewModels.GetInstance().Birth = new BirthdayViewModel();
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
