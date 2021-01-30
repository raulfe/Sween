using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sween.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var exit = await this.DisplayAlert("Sween", "¿Estas seguro de salir?", "Sí", "No").ConfigureAwait(false);

                if (exit)
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            });
            return true;
        }
    }
}