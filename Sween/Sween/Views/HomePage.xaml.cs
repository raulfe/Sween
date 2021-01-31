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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzkxNzQwQDMxMzgyZTM0MmUzMGU0MjVUNStaOWVKZ1NWSWtHSTVSQkEwRzRUK0hHSm1YeTNPOVBIamxmeEE9;MzkxNzQxQDMxMzgyZTM0MmUzMEVjUExhdk9ZdmZjVFczNkhiRytYVUJZQ0dBL0pyNjVVSmVuL1gyWlYrK289;MzkxNzQyQDMxMzgyZTM0MmUzME41R2VYRmtubEdFYVA5ZEthNEdIbFZBKzlnN051QUdYdk1ydElRV3Nybm89;MzkxNzQzQDMxMzgyZTM0MmUzMFFXS2RzZmxmNzh4UkJURzIycEI2SktLbEFoUHJ0TmJLWFArbU02T3hMcjQ9;MzkxNzQ0QDMxMzgyZTM0MmUzMEZKcURySmJaUkE2TzRYRlVIR0xaSnU5Z29hc2txZkVXK0JwZUtvKzRwTGc9;MzkxNzQ1QDMxMzgyZTM0MmUzMGE0VEtTYlZadmU5ZDZIOGZQd2dSRTY3Tkhtb3NLNlNoaHdDZVMvczdjcUU9;MzkxNzQ2QDMxMzgyZTM0MmUzMFRtVkttYkRKRTNNQlJZYm9sVldMNVhHLzlxT0xPK2dBVkhFVE9oRlFoVUk9;MzkxNzQ3QDMxMzgyZTM0MmUzMEtvZkRhQ0RzNXlLNDU4QXBlTVhRbHkyalFEcFlUNGFkWjBIRmdISzZyaTA9;MzkxNzQ4QDMxMzgyZTM0MmUzMFFFWkF4UVNjQlBQR3Q2Yy93N0dCUW5BSjJ2cCtxdXJETkRRZHdvaE8xenc9;MzkxNzQ5QDMxMzgyZTM0MmUzMFBoY1o3YlNpT052d2NmRGhJMzRvU2pNSFRzbVVVQVNWNXExZnNNdEh3NkE9");
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var url = new Uri(App.User.ImageURLSAS);
            ImageRT.Source = ImageSource.FromUri(url);
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var exit = await this.DisplayAlert("Sween", "¿Realmente quieres salir?", "Sí", "No").ConfigureAwait(false);
                if (exit)
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            });
            return true;
        }
    }
}