using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
            CryptocurrenciesValidation.InitiateCryptos();
            myCrypto = CryptocurrenciesValidation.cryptocurrencies["Ethereum"];
            //GivenName.Text = myCrypto.symbol + myCrypto.fullName;
            //QRImage.Source = myCrypto.imageFile;
            //Image myImage = new Image { Source = "emailicon.png", Style = (Style)Application.Current.Resources["WalletIcon"] };
            //WalletArea.Children.Add(myImage);
        }
        
        private void FiatAmount_TextChanged(object sender, TextChangedEventArgs e) {
            if (double.TryParse(FiatAmount.Text, out double d) && !Double.IsNaN(d) && d > 0 && !Double.IsInfinity(d)) {
                UpdateCryptoAmount(d);
            }          
        }

        public void UpdateCryptoAmount(double fiatAmount) {

            CryptoAmount.Text = (fiatAmount * myCrypto.GetRate()).ToString();
        }
    }
}
