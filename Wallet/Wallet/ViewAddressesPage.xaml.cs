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
    public partial class ViewAddressesPage : ContentPage {
        static ObservableCollection<UserAddress> userAddresses; // An observable collection is needed in order for the listview to auto update, not a List
        List<string> cryptoList = new List<string>();

        public ViewAddressesPage() {          
            InitializeComponent();            
            InitialiseCreatePopUp();
            InitialiseAddressListView();
        }

        //public static List<UserAddress> GetAddresses() {
        //    List<UserAddress> list = new List<UserAddress>();
        //    foreach (UserAddress address in userAddresses) list.Add(address);
        //    return list;
        //}

        public async void PopUpAlert(string message) {
            await DisplayAlert("Alert", message, "OK");
        }


        private void InitialiseCreatePopUp() {
            Overlay.IsVisible = false;
            cryptoList = CryptocurrenciesValidation.GetCryptoList();
            CryptoPicker.ItemsSource = cryptoList.OrderBy(s => s).ToList();
        }

        private void InitialiseAddressListView() {
            userAddresses = new ObservableCollection<UserAddress>(AddressDatabase.ReadDatabase());
            // Temporary addresses, ideally they would be loaded up first via file
            //userAddresses = new ObservableCollection<UserAddress>();
            //for (int i = 0; i < 8; i++) userAddresses.Add(new UserAddress("Example address " + i, "0x7223434442364", "Ethereum"));
            AddressesListView.ItemsSource = userAddresses;
        }

        // For create send a string (title) and a blue colour (background), for edit send a string and a red background or a Binding?
        private void Button_Clicked(object sender, EventArgs e) => CreatePopUp(); 
        
        // This is what happens when you use the asolute layout method for pop up. Technically the new controls are still part of this page.
        // Therefore the controls stay here on this class. If I had used a new Modal page, then it would have created a new class to deal with the pop up.
        // As it is everything below belongs to the pop up pseudo class
        // I could create a class for this later directly below this current class
        private void CreatePopUp() => Overlay.IsVisible = true;

        private void PasteButton_Clicked(object sender, EventArgs e) => PasteAddress();

        private async void PasteAddress() {
            if (Clipboard.HasText) {
                string clipboardText = await Clipboard.GetTextAsync();
                EnterAddressField.Text = clipboardText;
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e) => ClearPopUp();

        private void ClearPopUp() {
            Overlay.IsVisible = false;
            EnterAddressField.Text = "";
            AddressName.Text = "";
        }

        private void OkayButton_Clicked(object sender, EventArgs e) => AddNewAddress();

        private void AddNewAddress() {
            UserAddress newUserAddress = new UserAddress();
            newUserAddress.name = AddressName.Text;
            newUserAddress.address = EnterAddressField.Text;
            newUserAddress.crypto = CryptoPicker.SelectedItem.ToString();
            userAddresses.Add(newUserAddress);
            AddressesListView.ItemsSource = userAddresses;
            ClearPopUp();
        }
    }
}