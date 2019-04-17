﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet {
    public partial class App : Application {
        //Create new database
        //static string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //static string databasePath = Path.Combine(personalFolder, "addresses.db3");
        //static AddressesDatabase database;
        //public static AddressesDatabase Database {
        //    get {
        //        if (database == null) database = new AddressesDatabase(databasePath);
        //        return database;
        //    }
        //}

        public App() {
            InitializeComponent();

            //MainPage = new MainPage();
            
            //For 2 or more pages, MainPage needs to be renamed NavigationPage rather than the above 
            MainPage = new NavigationPage(new MainPage());
            
        }

        

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
