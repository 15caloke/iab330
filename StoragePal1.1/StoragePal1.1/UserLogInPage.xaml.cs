using StoragePal1.Models;
using StoragePal1.Databases;
using PCLCrypto;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Text;

namespace StoragePal1 {
    public partial class UserLogInPage : ContentPage {
        private readonly Database db;
        public UserLogInPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new SignUpPage());
        }

        private void TempLoginClicked(object sender, EventArgs e) {
            if (((MainViewModel)BindingContext).ValidateUser(usernameEntry.Text, passwordEntry.Text)) {
                Navigation.PushAsync(new StoragePal1_1Page());
            } else {
                // Need a better feeback mechanism
                usernameEntry.Text = "Username and/or Password Invalid";
            }
        }
    }
}
