﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAddresses : ContentPage {
        public ViewAddresses() {
            InitializeComponent();

            List<UserAddress> userAddresses = new List<UserAddress>();
            userAddresses.Add(new UserAddress("My 1st ETH address", "0x772682364", "Ethereum"));
            userAddresses.Add(new UserAddress("My 2nd ETH address", "0x7223434442364", "Ethereum"));
            AddressesListView.ItemsSource = userAddresses;

        }
    }
}