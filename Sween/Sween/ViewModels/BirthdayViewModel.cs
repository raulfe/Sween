using GalaSoft.MvvmLight.Command;
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

        #endregion

        #region Properties

        #endregion

        #region Constructor

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
            MainViewModels.GetInstance().Movil = new MovilViewModel();
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
