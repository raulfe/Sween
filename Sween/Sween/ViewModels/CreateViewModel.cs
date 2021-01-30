using GalaSoft.MvvmLight.Command;
using Sween.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class CreateViewModel:BaseViewModel
    {
        #region Constructor

        #endregion

        #region Properties

        #endregion

        #region Attributes

        #endregion

        #region Commands
        public ICommand NextCommand
        {
            get
            {
                return new RelayCommand(Next);
            }
        }

        public ICommand BackCommand
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
            MainViewModels.GetInstance().Birth = new BirthdayViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new BirthdayPage(), true);
        }

        private async void Back()
        {
            MainViewModels.GetInstance().Login = new LoginViewModel();
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
