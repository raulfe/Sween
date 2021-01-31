using GalaSoft.MvvmLight.Command;
using Sween.Models;
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
        public CreateViewModel()
        {
            User = new User();
            
        }
        #endregion

        #region Properties
        public User User { get { return user; } set { SetValue(ref user, value); } }
        #endregion

        #region Attributes
        private User user;
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
            MainViewModels.GetInstance().Birth = new BirthdayViewModel(this.User);
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
