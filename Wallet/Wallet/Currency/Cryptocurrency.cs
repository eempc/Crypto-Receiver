using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wallet {
    class Cryptocurrency : Currency {

        public Cryptocurrency(string symbol, string fullName, long smallestUnitDivider, string[] unitNames) :
            base (symbol, fullName, smallestUnitDivider, unitNames) {

        }

        public Cryptocurrency() {

        }

    }
}