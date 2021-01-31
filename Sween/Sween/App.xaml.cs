using Sween.Models;
using Sween.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sween
{
    public partial class App : Application
    {
        public static User User { get;  set; }
        public App()
        {
            InitializeComponent();
            var navPage = new NavigationPage(new LoginPage());
            MainPage = navPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
