using GalaSoft.MvvmLight.Command;
using Sween.Models;
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
        private User user;
        #endregion

        #region Propeties
        public User User { get { return user; } set { SetValue(ref user, value); } }
        #endregion

        #region Constructor
        public UsuarioViewModel(User User)
        {
            this.User = User;
        }
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
            
            MainViewModels.GetInstance().Pass = new PasswordViewModel(this.User);
            await App.Current.MainPage.Navigation.PushAsync(new PasswordPage(), true);
        }

        private async void Back()
        {
            MainViewModels.GetInstance().Movil = new MovilViewModel(this.User);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
