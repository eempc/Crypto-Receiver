using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Wallet {
    [Table("UserAddress")]
    public class UserAddress {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; } // For identifying in the SQLite database
        [MaxLength(64), Unique]
        public string name { get; set; } // E.g. "My first Ethereum address"
        [MaxLength(64)]
        public string address { get; set; } // "E.g. 0x89621f199bbc88a" Technically hexadecimal
        [MaxLength(64)]
        public string crypto { get; set; } // E.g. a string "Ethereum" 

        public string cryptoIconPath { get; set; }

        // Future modifications
        // I created the extra column to house the icon's path, this is wrong
        // What I need to do next is remove cryptoIconPath from this class
        // Then create a new class called ListViewUserAddressItem : UserAddress
        // In that new class, it inherits all the properties of UserAddress, and cryptoIconPath goes in there, it can also omit _id
        // The XAML's listview is then bound to ListViewUserAddressItem and not UserAddress
    }
}
