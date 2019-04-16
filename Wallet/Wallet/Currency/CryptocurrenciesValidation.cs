using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wallet {
    class CryptocurrenciesValidation {

        //This class is unnecessary and should probably be put into cryptocurrency

        public static Dictionary<string, Cryptocurrency> cryptocurrencies = new Dictionary<string, Cryptocurrency>();
        
        public static void InitiateCryptos() {
            cryptocurrencies.Add("Ethereum", new Cryptocurrency(
                "ETH", 
                "Ethereum", 
                new Dictionary<string, int>() { {"ether", 0 }, {"finney", 3}, {"szabo", 6}, {"shannon", 9}, {"lovelace", 12}, {"babbage", 15}, {"wei", 18} },
                "waterdrop.png"
                ));
            cryptocurrencies.Add("Bitcoin", new Cryptocurrency(
                "BTC", "Bitcoin", new Dictionary<string, int>() {{"bitcoin", 0 }, {"satoshi", 8}}, "waterdrop.png"
                ));
            cryptocurrencies.Add("Monero", new Cryptocurrency(
                "XMR", "Monero", new Dictionary<string, int>() { {"monero", 0 }, {"piconero", 12} }, "waterdrop.png"
                ));
        }

        public static List<string> GetCryptoList() {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, Cryptocurrency> entry in cryptocurrencies) {
                list.Add(entry.Value.fullName); // Same as entry.Key but probably best to use the object property
            }
            return list;
        }


    }
}