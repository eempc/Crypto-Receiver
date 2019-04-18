using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Wallet {
    [Table("UserAddress")]
    public class UserAddress : AddressProperties {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        [MaxLength(64), Unique]
        public string name { get; set; }
        [MaxLength(64)]
        public string address { get; set; }
        [MaxLength(64)]
        public string crypto { get; set; } // Select a crypto from the validation class
        
        // Constructor not needed with get set. Mght add it back later
        //public UserAddress(string name, string address, string crypto) {
        //    this.name = name;
        //    this.address = address;
        //    this.crypto = crypto;          
        //}

        public UserAddress() {
            cryptoIconPath = CryptocurrenciesValidation.cryptocurrencies[crypto].imageFile; // Jesus christ
        }
    }
}
