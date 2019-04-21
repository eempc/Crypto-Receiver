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
        int currentAddressIndex;
        //ryptocurrency myCrypto = new Cryptocurrency();
        List<UserAddress> addresses;
        public MainPage() {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CryptocurrenciesValidation.InitiateCryptos();
            AddressDatabase.CreateDatabase();
            //AddressDatabase.SetCurrentAddresses();
            
            //myCrypto = CryptocurrenciesValidation.cryptocurrencies["Ethereum"];
            //GivenName.Text = myCrypto.symbol + myCrypto.fullName;
            //QRImage.Source = myCrypto.imageFile;
            //Image myImage = new Image { Source = "emailicon.png", Style = (Style)Application.Current.Resources["WalletIcon"] };
            //WalletArea.Children.Add(myImage);

            //Temporary button event set up
            var iconTap = new TapGestureRecognizer();
            iconTap.Tapped += (object sender, EventArgs e) => { GoToAddPage(); };

            Image ic = BurgerIcon;
            ic.GestureRecognizers.Add(iconTap);

            // Not having the save file is causing major problems, it has to be addressed first
            //PopulateWalletArea();
        }
        
        private void PopulateWalletArea() {
            addresses = AddressDatabase.ReadDatabase();
            BindableLayout.SetItemsSource(WalletArea, addresses);
        }

        protected override void OnAppearing() {
            PopulateWalletArea();
        }

        private void FiatAmount_TextChanged(object sender, TextChangedEventArgs e) {
            if (double.TryParse(FiatAmount.Text, out double d) && !Double.IsNaN(d) && d > 0 && !Double.IsInfinity(d)) {
                UpdateCryptoAmount(d);
            }          
        }

        public void UpdateCryptoAmount(double fiatAmount) => CryptoAmount.Text = (fiatAmount).ToString();
        
        public async void GoToAddPage() => await Navigation.PushAsync(new ViewAddressesPage { Title = "Address CRUD Page" });
        
        public void LoadAddress(string x) {
            if (int.TryParse(x, out int number)) {
                //await DisplayAlert("Alert", i.ToString(), "OK");
                UserAddress address = AddressDatabase.GetItemById(number);
                SetAddressView(address);
            }
        }

        public void SetAddressView(UserAddress address) {
            string cryptoName = address.crypto;
            Header.Text = cryptoName;
            TopLeftIcon.Source = CryptocurrenciesValidation.cryptocurrencies[cryptoName].imageFile;
            GivenName.Text = address.name;
            CryptoAddress.Text = address.address; //.yeah well done here rofl
            // Etherscan image source
            // Feed box changes
            SetQRCode(address.address);

        }

        public void SetQRCode(string str) {

            
        }

        // Wallet area button handlers
        private void ImageButtonFlex_Clicked(object sender, EventArgs e) {
            var x = ((ImageButton)sender).ClassId;

            //await DisplayAlert("Alert", x, "OK");

            LoadAddress(x);
        }
    }
}
