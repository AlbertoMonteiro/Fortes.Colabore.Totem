using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Fortes.Colabore.Totem.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string barCodeValue = "QR não lido";

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await OpenQRCodeScanAsync());
        }

        private async Task OpenQRCodeScanAsync()
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    BarCodeValue = result.Text;
                    await Shell.Current.Navigation.PopAsync();
                });
            };

            await Shell.Current.Navigation.PushAsync(scanPage);
        }

        public ICommand OpenWebCommand { get; }
        public string BarCodeValue 
        { 
            get => barCodeValue; 
            set => SetProperty(ref barCodeValue, value); 
        }
    }
}