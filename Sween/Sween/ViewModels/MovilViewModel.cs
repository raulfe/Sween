using GalaSoft.MvvmLight.Command;
using Sween.Models;
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
        private User user;
        #endregion

        #region Properties
        public User User { get { return user; } set { SetValue(ref user, value); } }
        #endregion

        #region Constructor
        public MovilViewModel(User User)
        {
            this.User = User;
        }
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
            
            MainViewModels.GetInstance().User = new UsuarioViewModel(this.User);
            await App.Current.MainPage.Navigation.PushAsync(new UsuarioPage(), true);
        }

        private async void Back()
        {
            MainViewModels.GetInstance().Birth = new BirthdayViewModel(this.User);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
