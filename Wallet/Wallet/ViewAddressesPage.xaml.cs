using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        // enum AddEdit {Add, Edit };
        bool isAdd;

        public ViewAddressesPage() {          
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
            userAddresses = new ObservableCollection<UserAddress>(AddressDatabase.ReadDatabase());
            AddressesListView.ItemsSource = userAddresses;
        }

        private void AddButton_Clicked(object sender, EventArgs e) {
            CreatePopUp("Create address");
            updateIdGlobal = 0;
        }

        // Make pop up entry form visible. Populate if it is an edit
        private void CreatePopUp(string heading, string name = "", string address = "", int pickerIndex = -1) {
            Overlay.IsVisible = true;
            PopUpLabel.Text = heading;
            CryptoPicker.SelectedIndex = pickerIndex;
            AddressName.Text = name;
            EnterAddressField.Text = address;
        }

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

        private void OkayButton_Clicked(object sender, EventArgs e) => SaveAddress();

        int updateIdGlobal; // updated by tappedItem.id global variable
        private void SaveAddress() {
            UserAddress address = new UserAddress();
            address.name = AddressName.Text;
            address.address = EnterAddressField.Text;
            address.crypto = CryptoPicker.SelectedItem.ToString();
            address.cryptoIconPath = CryptocurrenciesValidation.cryptocurrencies[CryptoPicker.SelectedItem.ToString()].imageFile; // This is a bad line
            address.id = updateIdGlobal;
            ClearPopUp();
            AddressDatabase.SaveToDatabase(address);
            RefreshListView();
        }

        private async void AddressesListView_ItemTapped(object sender, ItemTappedEventArgs e) {
            UserAddress tappedItem = (UserAddress)((ListView)sender).SelectedItem;
            string action = await DisplayActionSheet("Action on " + tappedItem.name, "Cancel", null, "Delete", "Edit", "Copy address");

            if (action == "Delete") {
                AddressDatabase.DeleteFromDatabase(tappedItem.id);
                userAddresses.Remove(userAddresses.Where(x => x.id == tappedItem.id).Single()); // x refers to each item in the collection
            } else if (action == "Copy address") {
                await Clipboard.SetTextAsync(tappedItem.address);
            } else if (action == "Edit") {
                int index = CryptoPicker.ItemsSource.IndexOf(tappedItem.crypto);
                CreatePopUp("Edit address", tappedItem.name, tappedItem.address, index);
                updateIdGlobal = tappedItem.id;
            }
        }

        private void RefreshListView() {
            userAddresses.Clear();
            userAddresses = new ObservableCollection<UserAddress>(AddressDatabase.ReadDatabase());
            AddressesListView.ItemsSource = userAddresses; // Unnecessary with an Observable Collection
        }


        private void MenuItem_Clicked(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            DisplayAlert("Action 1", mi.CommandParameter.ToString() + " 1", "OK");

        }

        private void MenuItem_Clicked_1(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            DisplayAlert("Action 2", mi.CommandParameter.ToString() + " 2", "OK");
        }


        private void AddressesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {

        }
    }
}