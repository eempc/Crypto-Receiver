using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAddresses : ContentPage {
        public ViewAddresses() {
            InitializeComponent();

            List<UserAddress> userAddresses = new List<UserAddress>();
            userAddresses.Add(new UserAddress("My 1st ETH address", "0x772682364", "Ethereum"));
            for (int i = 0; i < 15; i++) userAddresses.Add(new UserAddress("MyETH address " + i, "0x7223434442364", "Ethereum"));
            AddressesListView.ItemsSource = userAddresses;
            
        }

        private void Button_Clicked(object sender, EventArgs e) {
            ActivateAddModalPage();
        }

        private void ActivateAddModalPage() {
            
        }
    }
}