using StoragePal1.Models;
using StoragePal1.Databases;
using PCLCrypto;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Text;

namespace StoragePal1 {
    public partial class UserLogInPage : ContentPage {
        private Database db;
        public UserLogInPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
        async void OnSignUpButtonClicked(Object sender, EventArgs e) {
            await Navigation.PushAsync(new SignUpPage());
        }

        // DELETE THE BELOW COMMAND ///
        async void TempLoginClicked(Object sender, EventArgs e) {
            await Navigation.PushAsync(new StoragePal1_1Page());
        }
        // DELETE THE ABOVE CODE //

        /*
         * Code for validation however it does not work
         */
        //private void TempLoginClicked(Object sender, EventArgs e) {
        //    ValidateUser((Entry)sender, (Entry)sender);
        //}

        //private void ValidateUser(Entry username, Entry password) {
        //    foreach (Users x in db.FetchAllUsers()) {
        //        if (x.Username == username.Text && x.Password == CalculateSha1Hash(password.Text)) {
        //            Navigation.PushAsync(new StoragePal1_1Page());
        //        } else {
        //            DisplayAlert("Invalid user", "Your username or password is incorrect", "OK");
        //        }
        //    }
        //}

        //private static string CalculateSha1Hash(string input) {
        //    // step 1, calculate MD5 hash from input
        //    var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
        //    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        //    byte[] hash = hasher.HashData(inputBytes);

        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < hash.Length; i++) {
        //        sb.Append(hash[i].ToString("X2"));
        //    }
        //    return sb.ToString();
        //}
    }
}
