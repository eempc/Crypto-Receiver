using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Wallet {
    public class Currency {
        public string symbol { get; set; }
        public string fullName { get; set; }
        public Dictionary<string, int> unitNames { get; set; }
        public string imageFile { get; set; }

        public Currency(string symbol, string fullName, Dictionary<string, int> unitNames, string imageFile) {
            this.symbol = symbol;
            this.fullName = fullName;
            this.unitNames = unitNames;
            this.imageFile = imageFile;
        }

        public Currency() {

        }

        public double GetRate() {
            // https://stackoverflow.com/questions/13019433/calling-a-method-every-x-minutes/23323647
            return 5.0;
        }
    }
}