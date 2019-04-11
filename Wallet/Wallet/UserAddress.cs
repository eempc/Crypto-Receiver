using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet {
    class UserAddress {
        public string name { get; set; }
        public string address { get; set; }
        public string crypto { get; set; } // Select a crypto from the validation class
        
        public UserAddress(string name, string address, string crypto) {
            this.name = name;
            this.address = address;
            this.crypto = crypto;
            
        }

        public UserAddress() {

        }
    }
}
