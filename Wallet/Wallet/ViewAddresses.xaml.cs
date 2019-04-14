using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAddresses : ContentPage {
        ObservableCollection<UserAddress> userAddresses; // An observable collection is needed in order for the listview to auto update
        List<string> cryptoList = new List<string>();
        public ViewAddresses() {
            
            InitializeComponent();            
            InitialiseCreatePopUp();
            InitialiseAddressListView();

        }

        private void InitialiseCreatePopUp() {
            Overlay.IsVisible = false;
            cryptoList = CryptocurrenciesValidation.GetCryptoList();
            CryptoPicker.ItemsSource = cryptoList.OrderBy(s => s).ToList();
        }

        private void InitialiseAddressListView() {
            userAddresses = new ObservableCollection<UserAddress>();
            userAddresses.Add(new UserAddress("My 1st ETH address", "0x772682364", "Ethereum"));
            for (int i = 0; i < 8; i++) userAddresses.Add(new UserAddress("MyETH address " + i, "0x7223434442364", "Ethereum"));
            AddressesListView.ItemsSource = userAddresses;
        }

        // For create send a string (title) and a blue colour (background), for edit send a string and a red background
        private void Button_Clicked(object sender, EventArgs e) => CreatePopUp(); 
        
        private async void CreatePopUp() {
            Overlay.IsVisible = true;
            await DisplayAlert("Alert", userAddresses.Count().ToString(), "OK");
        }

        private async void PasteButton_Clicked(object sender, EventArgs e) {
            if (Clipboard.HasText) {
                string clipboardText = await Clipboard.GetTextAsync();
                EnterAddressField.Text = clipboardText;
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e) {

        }

        private async void OkayButton_Clicked(object sender, EventArgs e) {
            userAddresses.Add(new UserAddress(AddressName.Text, EnterAddressField.Text, cryptoList[CryptoPicker.SelectedIndex]));
            Overlay.IsVisible = false;
            AddressesListView.ItemsSource = userAddresses;
            await DisplayAlert("Alert", userAddresses.Count().ToString(), "OK");
        }
    }
}