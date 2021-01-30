using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.ViewModels
{
    public class MainViewModels
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public CreateViewModel Create { get; set; }
        public BirthdayViewModel Birth { get; set; }
        public MovilViewModel Movil { get; set; }
        public UsuarioViewModel User { get; set; }
        public PasswordViewModel Pass { get; set; }
        #endregion

        #region Constructor
        public MainViewModels()
        {
            Instance = this;
            this.Login = new LoginViewModel();

        }

        #endregion

        #region Singleton
        private static MainViewModels Instance { get; set; }


        public static MainViewModels GetInstance()
        {
            if (Instance == null)
            {
                return new MainViewModels();
            }
            return Instance;
        }
        #endregion
    }
}
