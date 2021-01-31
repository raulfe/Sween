using GalaSoft.MvvmLight.Command;
using Sween.Models;
using Sween.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sween.ViewModels
{
    public class BirthdayViewModel : BaseViewModel
    {
        #region Attributes
        private User user;
        private DateTime birthday;
        #endregion

        #region Properties
        public User User { get { return user; } set { SetValue(ref user, value); } }
        public DateTime Birthday { get { return birthday; } set { SetValue(ref birthday, value); } }
        #endregion

        #region Constructor
        public BirthdayViewModel(User User)
        {
            this.User = User;
        }
        #endregion

        #region Commands
        public ICommand Next1Command
        {
            get
            {
                return new RelayCommand(Next);
            }
        }

        public ICommand Back1Command
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
            this.User.Birthday = Birthday.ToString("yyyy-MM-dd");
            MainViewModels.GetInstance().Movil = new MovilViewModel(this.User);
            await App.Current.MainPage.Navigation.PushAsync(new MovilPage(), true);
        }

        private async void Back()
        {
            MainViewModels.GetInstance().Create = new CreateViewModel();
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
