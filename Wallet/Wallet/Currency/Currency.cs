using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wallet {
    public class Currency {
        public string symbol { get; set; }
        public string fullName { get; set; }
        public long smallestUnitDivider { get; set; }
        public string[] unitNames { get; set; }

        public Currency(string symbol, string fullName, long smallestUnitDivider, string[] unitNames) {
            this.symbol = symbol;
            this.fullName = fullName;
            this.smallestUnitDivider = smallestUnitDivider;
            this.unitNames = unitNames;
        }

        public Currency() {

        }

        public double RateFeed(string url) {
            return 0;
        }
    }
}