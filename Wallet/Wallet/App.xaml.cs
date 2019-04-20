using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet {
    public partial class App : Application {
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
