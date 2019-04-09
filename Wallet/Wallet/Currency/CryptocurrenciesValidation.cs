using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wallet {
    class CryptocurrenciesValidation {

        public static Dictionary<string, Cryptocurrency> cryptocurrencies = new Dictionary<string, Cryptocurrency>();
        
        public static void InitiateCryptos() {
            cryptocurrencies.Add("Ethereum", new Cryptocurrency(
                "ETH", "Ethereum",1000000000000000000,
                new string[] { "wei", "babbage", "lovelace", "shannon", "szabo", "finney", "ether" }
            ));
            cryptocurrencies.Add("Bitcoin", new Cryptocurrency(
                "BTC", "Bitcoin", 100000000,
                new string[] { "satoshi", "babbage", "lovelace", "shannon", "szabo", "finney", "ether" }
            ));
        }



    }
}