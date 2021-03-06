﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace Wallet {
    public class AddressDatabase {
        static string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string databasePath = Path.Combine(personalFolder, "addresses001.db3");
        //public static ObservableCollection<UserAddress> currentAddresses;

        public static void CreateDatabase() {
            if (!File.Exists(databasePath)) {
                SQLiteConnection db = new SQLiteConnection(databasePath);
                db.CreateTable<UserAddress>();
                UserAddress seedingAddress = new UserAddress();
                seedingAddress.name = "My first Ethereum address";
                seedingAddress.address = "0xd26114cd6EE289AccF82350c8d8487fedB8A0C07";
                seedingAddress.crypto = "Ethereum";
                seedingAddress.cryptoIconPath = CryptocurrenciesValidation.cryptocurrencies["Ethereum"].imageFile;
                db.Insert(seedingAddress);
            }
        }

        //public static void SetCurrentAddresses() {
        //    currentAddresses = new ObservableCollection<UserAddress>(ReadDatabase());
        //}


        public static List<UserAddress> ReadDatabase() {
            List<UserAddress> list = new List<UserAddress>();
            SQLiteConnection db = new SQLiteConnection(databasePath);
            var table = db.Table<UserAddress>();
            foreach (var item in table) {
                list.Add(item);
            }
            return list;
        }

        public static void DeleteFromDatabase(int id) {
            SQLiteConnection db = new SQLiteConnection(databasePath);
            db.Delete<UserAddress>(id);
        }

        public static void SaveToDatabase(UserAddress address) {
            SQLiteConnection db = new SQLiteConnection(databasePath);
            if (address.id <= 0) {
                db.Insert(address);
            } else {
                db.Update(address);
            }
        }

        public static UserAddress GetItemById(int number) {
            SQLiteConnection db = new SQLiteConnection(databasePath);
            return db.Table<UserAddress>().Where(x => x.id == number).FirstOrDefault();
        }
    }
}
