using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wallet {
    class Cryptocurrency : Currency {

        public Cryptocurrency(string symbol, string fullName, Dictionary<string, int> unitNames, string imageFile) :
            base (symbol, fullName, unitNames, imageFile) {

        }

        public Cryptocurrency() {

        }

    }
}