using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace Wallet {
    public class AddressDatabase {
        static string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string databasePath = Path.Combine(personalFolder, "addresses.db3");

        //public AddressDatabase() {
        //    var db = new SQLiteConnection(databasePath);
        //}
        
        public static void CreateDatabase() {           
            SQLiteConnection db = new SQLiteConnection(databasePath);
            db.CreateTable<UserAddress>();
            UserAddress seedingAddress = new UserAddress();
            seedingAddress.name = "My first Ethereum address";
            seedingAddress.address = "0xd26114cd6EE289AccF82350c8d8487fedB8A0C07";
            seedingAddress.crypto = "Ethereum";
            db.Insert(seedingAddress);           
        }

        public static List<UserAddress> ReadDatabase() {
            List<UserAddress> list = new List<UserAddress>();
            SQLiteConnection db = new SQLiteConnection(databasePath);
            var table = db.Table<UserAddress>();
            foreach (var item in table) {
                list.Add(item);
            }
            return list;
        }

    }
}
