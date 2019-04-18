using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wallet {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage {
        Cryptocurrency myCrypto = new Cryptocurrency();

        public MainPage() {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CryptocurrenciesValidation.InitiateCryptos();
            AddressDatabase.CreateDatabase();
            
            myCrypto = CryptocurrenciesValidation.cryptocurrencies["Ethereum"];
            //GivenName.Text = myCrypto.symbol + myCrypto.fullName;
            //QRImage.Source = myCrypto.imageFile;
            //Image myImage = new Image { Source = "emailicon.png", Style = (Style)Application.Current.Resources["WalletIcon"] };
            //WalletArea.Children.Add(myImage);

            //Temporary button event set up
            var iconTap = new TapGestureRecognizer();
            iconTap.Tapped += (object sender, EventArgs e) => { GoToAddPage(); };

            Image ic = TopLeftIcon;
            ic.GestureRecognizers.Add(iconTap);

            // Not having the save file is causing major problems, it has to be addressed first
            //PopulateWalletArea();
        }
        
        private void PopulateWalletArea() {
            // Currently pinching the observable collection list from viewaddresses rather than the storage file
            //List<UserAddress> walletAddresses = ViewAddresses.GetAddresses();

            //for (int i = 0; i < walletAddresses.Count(); i++) {
            //    Image image = new Image { Source = "emailicon.png", Style = (Style)Application.Current.Resources["WalletIcon"] };
            //}

        }

        private void FiatAmount_TextChanged(object sender, TextChangedEventArgs e) {
            if (double.TryParse(FiatAmount.Text, out double d) && !Double.IsNaN(d) && d > 0 && !Double.IsInfinity(d)) {
                UpdateCryptoAmount(d);
            }          
        }

        public void UpdateCryptoAmount(double fiatAmount) => CryptoAmount.Text = (fiatAmount * myCrypto.GetRate()).ToString();
        
        public async void GoToAddPage() => await Navigation.PushAsync(new ViewAddressesPage { Title = "Address CRUD Page" });
        
        public void CurrentlyDisplayedAddress(UserAddress address) {

        }

    }
}
