using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet {
    class UserAddress {
        public string address { get; set; }
        public string crypto { get; set; } // Select a crypto from the validation class
        public string name { get; set; }

        public UserAddress(string address, string crypto, string name) {
            this.address = address;
            this.crypto = crypto;
            this.name = name;
        }
    }
}
